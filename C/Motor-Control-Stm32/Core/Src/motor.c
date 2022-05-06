#include "motor.h"
#include "registers.h"

/* -------------------------------------------------------------------------------------------------------------
 *  Motor Control and Initialization Functions
 * -------------------------------------------------------------------------------------------------------------
 */
#include "motor.h"

// Integrated error signal
volatile int16_t Error_Integral = 0;
// Desired speed target
volatile int16_t Target_Rpm = 0;
// Measured motor speed
volatile int16_t Motor_Speed = 0;
// Speed error signal
volatile int16_t Error = 0;
// Proportional gain
volatile uint8_t Kp = 0;
// Integral gain
volatile uint8_t Ki = 0;
// Motor Direction
volatile uint8_t Direction = 2;
// Display speed
volatile uint8_t Out_Put_Speed=0;
// Output
volatile int16_t Output=0;

// Sets up the entire motor drive system
void Init_MOTOR(void)
{
Init_PWM();
Init_ENCODER();
}
// Sets up the PWM and direction signals to drive the H-Bridge
void Init_PWM(void)
{
// Reset clock control GPIOA enable
AHB                  |= (0x1UL << 17U);
// Reset clock control TIM14 enable
APB                  |= (0x1 << 8U);
// Set up a PA5, PA6 as GPIO output pins for motor direction control & pin PA4 for H-bridge PWM output
MODA                 |= (0x1UL << 9U) | (0x1UL << 18U) | (0x1UL << 20U);
MODA                 &= ~(0x1UL << 8U);
// Set PA4 to AF4
ALTERNATE_FUNCA_0    &= 0xFFF0FFFF; 
ALTERNATE_FUNCA_0    |= (1 << 18);
// Set up PWM timer
// Clear control registers
CONTROL_REG_TIM_14_1 = 0;
// (prevents having to manually clear bits)
COM_MOD_REG_TIM_14_1 = 0;
COM_ENB_REG_TIM_14_1 = 0;
// Set output-compare CH1 to PWM1 mode and enable CCR1 preload buffer
COM_MOD_REG_TIM_14_1 |= (0x1UL << 3U)|(0x1UL << 5U)|(0x1UL << 6U);
// Enable capture-compare channel 1
COM_ENB_REG_TIM_14_1 |=   (0x1UL << 0U);
// Run timer on 24Mhz
PRESCALER_TIM_14     = 1;
// PWM at 20kHz
RELOAD_REG_TIM_14    = 1200;
// Start PWM at 0% duty cycle
COM_REG_TIM_14       = 0;
// Enable timer
CONTROL_REG_TIM_14_1 |= (0x1UL << 0U);
}
// Set the duty cycle of the PWM, accepts (0-100)
void PWM_DUTY_CYCLE(uint8_t Duty)
{
if(Duty <= 100)
{
// Use linear transform to produce CCR1 value
COM_REG_TIM_14 = ((uint32_t)Duty*RELOAD_REG_TIM_14)/100;  
}
}

void Init_ENCODER(void)
{
// Set up encoder input pins (TIMER 3 CH1 and CH2)
AHB                  |= (0x1UL << 18U);
// Set up encoder interface (TIM3 encoder input mode)
APB                  |= (0x1UL << 1);
// Configure a second timer (TIM6) to fire an ISR on update event
// Used to periodically check and update speed variable
APB                  |= (0x1UL << 4U);
// PIN 4 & 5 GPIOB
MODB                 &= ~(0x1UL << 8U)| (0x1UL << 10U);
MODB                 |=  (0x1UL << 9U)| (0x1UL << 11U);                       //(GPIO_MODER_MODER4_1 | GPIO_MODER_MODER5_1);
ALTERNATE_FUNCB_0    |= ( (1 << 16) | (1 << 20) );
COM_MOD_REG_TIM_3_1  = 0;
COM_ENB_REG_TIM_3_1  = 0;
SLAVE_MOD_REG_TIM_3  = 0;
CONTROL_REG_TIM_3_1  = 0;
// TI1FP1 and TI2FP2 signals connected to CH1 and CH2
COM_MOD_REG_TIM_3_1  |= (0x1UL << 0U)|(0x1UL << 8U);
// Capture encoder on both rising and falling edges
SLAVE_MOD_REG_TIM_3  |= (0x1UL << 0U)| (0x1UL << 1U);
// Set ARR to top of timer (longest possible period)
RELOAD_REG_TIM_3     = 0xFFFF;
// Bias at midpoint to allow for negative rotation (Could also cast unsigned register to signed number to get negative numbers
//if it rotates backwards past zero just another option, the mid-bias is a bit simpler to understand though.)
COUNTER_TIM_3        = 0x7FFF;
// Enable timer
CONTROL_REG_TIM_3_1  |= (0x1UL << 0);
// Configure a second timer (TIM6) to fire an ISR on update event
// Used to periodically check and update speed variable
// Select PSC and ARR values that give an appropriate interrupt rate
PRESCALER_TIM_6      = 11;
RELOAD_REG_TIM_6     = 30000;
// Enable update event interrupt
I_ENB_REG_TIM_6      |= (0x1UL << 0U);
// Enable Timer
CONTROL_REG_TIM_6_1  |= (0x1UL << 0U);
// Enable interrupt in NVIC
NVIC_EnableIRQ(TIM6_DAC_IRQn);
NVIC_SetPriority(TIM6_DAC_IRQn,2);
}

// Encoder interrupt to calculate motor speed, also manages PI controller
/* Calculate the motor speed in raw encoder counts
* Note the motor speed is signed! Motor can be run in reverse.
* Speed is measured by how far the counter moved from center point
*/
void TIM6_DAC_IRQHandler(void)
{
Motor_Speed = (COUNTER_TIM_3 -0x7FFF);
// Reset back to center point
COUNTER_TIM_3 = 0x7FFF;
// if rpm 100 we will get 100  not 200 as in speed motor variable 
Out_Put_Speed = abs(Motor_Speed/2);
// Call the PI update function
PI_LOOP();
// Acknowledge the interrupt
STATUS_REG_TIM_6 &= ~(0x1UL << 0U);
}

// PI control code is called within a timer interrupt
void PI_LOOP(void)
{
// check the direction requestion enable the right pin
if(Direction == 0)
{

OUTPUT_PORTA |= (0x1UL << 9U);
OUTPUT_PORTA &= ~(0x1UL <<10U);
Error = 2*Target_Rpm - Motor_Speed;
}
// check the direction requestion enable the right pin
else if(Direction == 1){
OUTPUT_PORTA |= (0x1UL << 10U);
OUTPUT_PORTA &= ~(0x1UL << 9U);
Error = 2*Target_Rpm + Motor_Speed;
}
// check the direction requestion disable the motor pin 
else if(Direction == 2)
{
while(OUTPUT_PORTA & 0x9){}
OUTPUT_PORTA &= ~(0x1UL << 9U);
while(OUTPUT_PORTA & 0x10){}
OUTPUT_PORTA &= ~(0x1UL << 10U);
}
// The Error_Integral value between 0 and 3200
if(Error_Integral >= 3200)
{
Error_Integral=3200;
}
else if(Error_Integral <= 0)
{
Error_Integral= 0;
}
// The output value between 0 and 100
if(Output >= 100){
Output=100;
 } 
else if(Output <= 0)
{
Output= 0;
}
// limited the speed for the GUI
if(Out_Put_Speed >100)
{
Out_Put_Speed=100;
}
// limited the error for the GUI
if(Error >100)
{
Error=100;
}
// Calcaute the Error_Integral
Error_Integral =  Error_Integral+Error*Ki;
// Calcaute the output
Output = (Kp*Error)+Error_Integral;
// If 3200 for the integral clamp right shift by 5 bit
// this will give you an output of 100 at maximum integral
Output = (Output)>>5;
// Set PWM_DUTY_CYCLE value
PWM_DUTY_CYCLE(Output);
}

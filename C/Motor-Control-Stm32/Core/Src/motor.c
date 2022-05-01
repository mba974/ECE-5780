#include "motor.h"
#include "registers.h"

/* -------------------------------------------------------------------------------------------------------------
 *  Motor Control and Initialization Functions
 * -------------------------------------------------------------------------------------------------------------
 */
#include "motor.h"

volatile int16_t Error_Integral = 0;    // Integrated error signal
volatile uint8_t Duty_Cycle = 0;        // Output PWM duty cycle
volatile int16_t Target_Rpm = 0;        // Desired speed target
volatile int16_t Motor_Speed = 0;       // Measured motor speed
volatile int16_t Error = 0;             // Speed error signal
volatile uint8_t Kp = 0;                // Proportional gain
volatile uint8_t Ki = 0;                // Integral gain
volatile uint8_t Direction = 2;         // Motor Direction
volatile uint8_t Out_Put_Speed=0 ;
volatile int16_t Output=0;

void Init_MOTOR(void)
{
Init_PWM();
Init_ENCODER();
}

void Init_PWM(void)
{

AHB |= (0x1UL << 17U); 
APB |= (0x1 << 8U);
MODA |= (1 << 9) | (0x1UL << 18U) | (0x1UL << 20U);
MODA &= ~(1 << 8);
ALTERNATE_FUNCA_0  &= 0xFFF0FFFF; 
ALTERNATE_FUNCA_0  |= (1 << 18);
CONTROL_REG_TIM_14_1 = 0;                        
COM_MOD_REG_TIM_14_1  = 0;                      
COM_ENB_REG_TIM_14_1 = 0;
COM_MOD_REG_TIM_14_1 |= (0x1UL << 3U)|(0x1UL << 5U)|(0x1UL << 6U);                 //(TIM_CCMR1_OC1M_2 | TIM_CCMR1_OC1M_1 | TIM_CCMR1_OC1PE);
COM_ENB_REG_TIM_14_1 |=   (0x1UL << 0U); // TIM_CCER_CC1E;        
PRESCALER_TIM_14      = 1;                       
RELOAD_REG_TIM_14     = 1200;                     
COM_REG_TIM_14 = 0;                        
CONTROL_REG_TIM_14_1 |= (0x1UL << 0U);    // TIM_CR1_CEN;            
}

void PWM_DUTY_CYCLE(uint8_t Duty)
{
if(Duty <= 100)
{
COM_REG_TIM_14 = ((uint32_t)Duty*RELOAD_REG_TIM_14)/100;  
}
}

void Init_ENCODER(void)
{

AHB                  |= (0x1UL << 18U);
APB                  |= (0x1UL << 1);
APB                  |= RCC_APB1ENR_TIM6EN;
MODB                 &= ~(0x1UL << 8U)| (0x1UL << 10U);                  //(GPIO_MODER_MODER4_0 | GPIO_MODER_MODER5_0);
MODB                 |=  (0x1UL << 9U)| (0x1UL << 11U);                       //(GPIO_MODER_MODER4_1 | GPIO_MODER_MODER5_1);
ALTERNATE_FUNCB_0    |= ( (1 << 16) | (1 << 20) );
COM_MOD_REG_TIM_3_1  = 0;
COM_ENB_REG_TIM_3_1  = 0;
SLAVE_MOD_REG_TIM_3  = 0;
CONTROL_REG_TIM_3_1  = 0;
COM_MOD_REG_TIM_3_1  |= (0x1UL << 0U)|(0x1UL << 8U);//////(TIM_CCMR1_CC1S_0 | TIM_CCMR1_CC2S_0);  
SLAVE_MOD_REG_TIM_3  |= (0x1UL << 0U)| (0x1UL << 1U);         ////// (TIM_SMCR_SMS_1 | TIM_SMCR_SMS_0);       
RELOAD_REG_TIM_3     = 0xFFFF;                                     
COUNTER_TIM_3        = 0x7FFF;                                   
CONTROL_REG_TIM_3_1  |= (0x1UL << 0);                               
PRESCALER_TIM_6      = 11;
RELOAD_REG_TIM_6     = 30000;
I_ENB_REG_TIM_6      |= (0x1UL << 0U);           //TIM_DIER_UIE;             
CONTROL_REG_TIM_6_1  |= (0x1UL << 0U);     //TIM_CR1_CEN;              
NVIC_EnableIRQ(TIM6_DAC_IRQn);          
NVIC_SetPriority(TIM6_DAC_IRQn,2);
}


//////////////////////////////////////////////////////////////////
void TIM6_DAC_IRQHandler(void)
{

Motor_Speed = (COUNTER_TIM_3 -0x7FFF);
COUNTER_TIM_3 = 0x7FFF; 
Out_Put_Speed = abs(Motor_Speed/2);
PI_LOOP();
STATUS_REG_TIM_6 &= ~(0x1UL << 0U);         //TIM_SR_UIF;        
}
/////////////////////////////////////////////////////////////////

////////////////////////////////////////////////////////////////
void PI_LOOP(void) { 
//////////////////////////////////////////////////////

//////////////////////////////////////////////////////

if(Direction == 0)
{

OUTPUT_PORTA |= (0x1UL << 9U);
OUTPUT_PORTA &= ~(0x1UL <<10U);
Error = 2*Target_Rpm - Motor_Speed;
}
else if(Direction == 1){
OUTPUT_PORTA |= (0x1UL << 10U);
OUTPUT_PORTA &= ~(0x1UL << 9U);
Error = 2*Target_Rpm + Motor_Speed;
}
else if(Direction == 2)
{
while(OUTPUT_PORTA & 0x9){}
OUTPUT_PORTA &= ~(0x1UL << 9U);
while(OUTPUT_PORTA & 0x10){}
OUTPUT_PORTA &= ~(0x1UL << 10U);
}
if(Error_Integral >= 3200)
{
Error_Integral=3200;
}
else if(Error_Integral <= 0)
{
Error_Integral= 0;
}
if(Output >= 100){
Output=100;
 } 
else if(Output <= 0)
{
Output= 0;
}
if(Out_Put_Speed >100)
{
Out_Put_Speed=100;
}

if(Error >100)
{
Error=100;
}
Error_Integral =  Error_Integral+Error*Ki;
Output = (Kp*Error)+Error_Integral; 
Output = (Output)>>5;
PWM_DUTY_CYCLE(Output);
Duty_Cycle = Output;           
}

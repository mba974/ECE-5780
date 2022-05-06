#ifndef MOTOR_H_
#define MOTOR_H_

#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

/* -------------------------------------------------------------------------------------------------------------
 *  Global Variable and Type Declarations
 *  -------------------------------------------------------------------------------------------------------------
 */
// Integrated error signal
extern volatile int16_t Error_Integral;
// Desired speed target
extern volatile int16_t Target_Rpm;
// Measured motor speed
extern volatile int16_t Motor_Speed;
// Speed Error signal
extern volatile int16_t Error;
// Proportional gain
extern volatile uint8_t Kp;
// Integral gain
extern volatile uint8_t Ki;
// Motor Direction
extern volatile uint8_t Direction;
// Display speed
extern volatile uint8_t Out_Put_Speed;
// Output
extern volatile int16_t Output;

/* -------------------------------------------------------------------------------------------------------------
 *  Motor Control and Initialization Functions
 * -------------------------------------------------------------------------------------------------------------
 */

// Sets up the entire motor drive system
void Init_MOTOR(void);

// Set the duty cycle of the PWM, accepts (0-100)
void PWM_DUTY_CYCLE(uint8_t Duty);

// PI control code is called within a timer interrupt
void PI_LOOP(void);


/* -------------------------------------------------------------------------------------------------------------
 *  Internal-Use Initialization Functions
 * -------------------------------------------------------------------------------------------------------------
 */

// Sets up the PWM and direction signals to drive the H-Bridge
void Init_PWM(void);

// Sets up encoder interface to read motor speed
void Init_ENCODER(void);

#endif /* MOTOR_H_ */


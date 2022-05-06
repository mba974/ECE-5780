#ifndef LED_H_
#define LED_H_
#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

/* -------------------------------------------------------------------------------------------------------------
 *  Global Variable and Type Declarations
 *  -------------------------------------------------------------------------------------------------------------
 */
// Set the I2c2 value to Angle_Degrees 0,1, 2 or 3
extern volatile short Angle_Degrees;
// Recalcluation for the  Angle_Degrees 90,180, 270 or 360
extern volatile short Convert_Value;
/* -------------------------------------------------------------------------------------------------------------
 *  LED and Initialization Functions
 * -------------------------------------------------------------------------------------------------------------
 */
 // Sets up the entire LED
void Init_LED(void);
// Tune the LED on off with Angle_Degrees
void LED(void);

#endif

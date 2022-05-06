#include "led.h"
#include "registers.h"
// Read the I2c2 value to Angle_Degrees 0,1, 2 or 3
volatile short Angle_Degrees  = 0;
// Recalcluation for the  Angle_Degrees 90,180, 270 or 360
volatile short Convert_Value  = 0;

// Tune the LEDs on off with Angle_Degrees
void LED(void)
{
switch(Angle_Degrees)
{
      case 0 :
            OUTPUT_PORTC |=  (0x1UL << 8U);
            OUTPUT_PORTC &= ~(0x1UL << 6U);
            OUTPUT_PORTC &= ~(0x1UL << 7U);
            OUTPUT_PORTC &= ~(0x1UL << 9U);
            Convert_Value = 90;
         break;
      case 1 :
            OUTPUT_PORTC |=  (0x1UL << 6U);
            OUTPUT_PORTC &= ~(0x1UL << 7U);
            OUTPUT_PORTC &= ~(0x1UL << 8U);
            OUTPUT_PORTC &= ~(0x1UL << 9U);
            Convert_Value = 180;
        break;
      case 2 :
            OUTPUT_PORTC |=  (0x1UL << 9U);
            OUTPUT_PORTC &= ~(0x1UL << 6U);
            OUTPUT_PORTC &= ~(0x1UL << 7U);
            OUTPUT_PORTC &= ~(0x1UL << 8U);
            Convert_Value =270;
         break;
      case 3 :
            OUTPUT_PORTC |=  (0x1UL << 7U);
            OUTPUT_PORTC &= ~(0x1UL << 6U);
            OUTPUT_PORTC &= ~(0x1UL << 8U);
            OUTPUT_PORTC &= ~(0x1UL << 9U);
            Convert_Value = 360;
         break;
      default :
            OUTPUT_PORTC &= ~(0x1UL << 7U);
            OUTPUT_PORTC &= ~(0x1UL << 6U);
            OUTPUT_PORTC &= ~(0x1UL << 8U);
            OUTPUT_PORTC &= ~(0x1UL << 9U);
}
}

// Sets up the entire LED
 void Init_LED(void)
{
// Reset clock control GPIOC enable
AHB  |=  (0x1UL << 19U);
// MODER set to OUTPUT for the 4 leds
MODC |=  (0x1UL << 12U)|(0x1UL << 14U)|(0x1UL << 16U)|(0x1UL << 18U);
MODC &= ~(0x1UL << 13U)|(0x1UL << 15U)|(0x1UL << 17U)|(0x1UL << 19U);
// Output type register set to Output push-pull for the 4 leds
OTYC &= ~(0x1UL << 6U)|(0x1UL << 7U)|(0x1UL << 8U)|(0x1UL << 9U);
// Output speed register set to Low speed for the 4 leds
OSPC &= ~(0x1UL << 12U)|(0x1UL << 14U)|(0x1UL << 16U)|(0x1UL << 18U);
// Pull-up/pull-down register set to  No pull-up, pull-down for the 4 leds
PUPC &= ~(0x1UL << 12U)|(0x1UL << 14U)|(0x1UL << 16U)|(0x1UL << 18U)|(0x1UL << 13U)|(0x1UL << 15U)|(0x1UL << 17U)|(0x1UL << 19U);
}

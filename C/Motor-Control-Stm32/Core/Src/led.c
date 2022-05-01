#include "led.h"
#include "registers.h"

volatile short Angle_Degrees  = 0;
volatile short Convert_Value  = 0;

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

 void Init_LED(void)
{

AHB |= (0x1UL << 19U);
MODC |= (0x1UL << 12U)|(0x1UL << 14U)|(0x1UL << 16U)|(0x1UL << 18U);
MODC &= ~(0x1UL << 13U)|(0x1UL << 15U)|(0x1UL << 17U)|(0x1UL << 19U);
OTYC &= ~(0x1UL << 6U)|(0x1UL << 7U)|(0x1UL << 8U)|(0x1UL << 9U);
OSPC &= ~(0x1UL << 12U)|(0x1UL << 14U)|(0x1UL << 16U)|(0x1UL << 18U);
PUPC &= ~(0x1UL << 12U)|(0x1UL << 14U)|(0x1UL << 16U)|(0x1UL << 18U);
PUPC &= ~(0x1UL << 13U)|(0x1UL << 15U)|(0x1UL << 17U)|(0x1UL << 19U);
}

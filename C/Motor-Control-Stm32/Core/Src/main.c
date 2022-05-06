#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"
#include "motor.h"
#include "usart.h"
#include "i2c.h"
#include "led.h"
#include "registers.h"

uint32_t DeviceID;

void Device_ID(uint32_t *Serial_Number)
{
Serial_Number[0] = (uint32_t)(READ_REG(*((uint32_t *) UNIQUE_DEVICE_ID)));
Serial_Number[1] = (uint32_t)(READ_REG(*((uint32_t *)(UNIQUE_DEVICE_ID + 4U))));
Serial_Number[2] = (uint32_t)(READ_REG(*((uint32_t *)(UNIQUE_DEVICE_ID + 8U))));
}
/* 
-----------------------------------------------------------------------------------
--------------------------
 * Main Program Code
 *
 * Starts initialization of peripherals
 * Unique device id
 * 
-----------------------------------------------------------------------------------
--------------------------
 */
int main()
{
// Initialize USART-3
Init_USART();
// Initialize MOTOR
Init_MOTOR();
// Initialize I2C2
Init_I2C();
// Initialize LEDS
Init_LED();
// Initialize Device_ID
Device_ID(&DeviceID);

    while (1)
{
// Read angle degrees and store it in Angle_Degrees vaiable 
Output_Value(&Angle_Degrees);
// Turn leds on/off depend on angle position
LED();
// Transmit the data to the serial port
// Transmit the motor speed
Transmit_USART(Out_Put_Speed);
SEND_MESSAGE("speed:");
// Transmit the Error %
Transmit_USART(Error);
SEND_MESSAGE("error:");
// Transmit the angle degrees
Transmit_USART(Convert_Value);
SEND_MESSAGE("rotat:");
// Transmit the device ID
Transmit_USART(DeviceID);
SEND_MESSAGE("devic:");
// Make New Line
SEND_MESSAGE("\r\n");
// Delay 50ms
HAL_Delay(50);
}
}

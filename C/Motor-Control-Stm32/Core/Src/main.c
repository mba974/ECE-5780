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

int main()
{
Init_USART();
Init_MOTOR();
Init_I2C();
Init_LED();
Device_ID(&DeviceID);

    while (1)
{
Output_Value(&Angle_Degrees);
LED();
Transmit_USART(Out_Put_Speed);
SEND_MESSAGE("speed:");
Transmit_USART(Error);
SEND_MESSAGE("error:");
Transmit_USART(Convert_Value);
SEND_MESSAGE("rotat:");
Transmit_USART(DeviceID);
SEND_MESSAGE("devic:");
SEND_MESSAGE("\r\n");
HAL_Delay(50);
}
}

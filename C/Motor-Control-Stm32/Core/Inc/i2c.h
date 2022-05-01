#ifndef I2C2_H_
#define I2C2_H_

#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

void Init_I2C(void);
void Start_I2C(int Number_Byte);
void Stop_I2C(void);
void Start_Write(int Number_Byte_Write);
void Transmit_Byte(uint16_t Byte_Transmit);
void Start_Read(int Number_Byte_Read);
unsigned char Read_Byte(void);
uint8_t Read_Register(long Register_Address);
short Value_Register(unsigned char Address_Read);
void Output_Value(volatile short* Read_Value);

#endif /* MOTOR_H_ */

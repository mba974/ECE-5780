#ifndef I2C2_H_
#define I2C2_H_

#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"
/* 
-----------------------------------------------------------------------------------
--------------------------
 *  I2C2 and Initialization Functions and Internal-Use Initialization Functions
 * 
-----------------------------------------------------------------------------------
--------------------------
 */
// Sets up the entire I2c2 device system
void Init_I2C(void);
// Set the number byte to send and establish the start condtion and confirming the start
void Start_I2C(int Number_Byte);

// Establish the stop condtion and confirming the stop
void Stop_I2C(void);

// Set the number byte write to send 
void Start_Write(int Number_Byte_Write);

// write abyte to transimitdtat and confirming the txdr not empty
void Transmit_Byte(uint16_t Byte_Transmit);

// Set the read and write
void Start_Read(int Number_Byte_Read);

// read RXNE status and return RXDR
unsigned char Read_Byte(void);

// Read register address value
uint8_t Read_Register(long Register_Address);

// calclaute register address value MSB and LSB
short Value_Register(unsigned char Address_Read);

//retun the final value of register
void Output_Value(volatile short* Read_Value);

#endif /* MOTOR_H_ */

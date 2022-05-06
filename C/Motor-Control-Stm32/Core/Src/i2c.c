/* 
-----------------------------------------------------------------------------------
--------------------------
 *  I2C2 and Initialization Functions and Internal-Use Initialization Functions
 * 
-----------------------------------------------------------------------------------
--------------------------
 */
#include "i2c.h"
#include "registers.h"

// Set the number byte to send and establish the start condtion and confirming the start
void Start_I2C(int Number_Byte)
{
// Reset before send the number of byte
CONTROL_REG_I2C2_2 &= ~(0xFF<<16);
// Set the number of byte to send and establish the start condition
CONTROL_REG_I2C2_2 |= (Number_Byte<<16) | I2C_CR2_START;
// Confirming the satrt condition
while(CONTROL_REG_I2C2_2 &( 0x1UL << 13U)){};
}

// Establish the stop condtion and confirming the stop
void Stop_I2C(void)
{
// Establish the stop condition
CONTROL_REG_I2C2_2 |= (0x1UL << 14U);
// Confirming the stop condtion
while(CONTROL_REG_I2C2_2 & (0x1UL << 14U)){};
}

// Set the number byte write to send 
void Start_Write(int Number_Byte_Write)
{
// Set the read & write bit to write
CONTROL_REG_I2C2_2 &= ~(0x1UL << 10U);
// Set the number byte to send
Start_I2C(Number_Byte_Write);
}

// Write abyte to transimitdtat and confirming the txdr not empty
void Transmit_Byte(uint16_t Byte_Transmit)
{
// Write the byte to transmit data register
TRANSMIT_DATA = Byte_Transmit;
// Confirming transmit by making sure the TXDR is empty
while(!(STATUS_REG_I2C2 & (0x1UL << 0U))){};
}

// Set the read and write
void Start_Read(int Number_Byte_Read)
{
// Set the read & write bit to write
CONTROL_REG_I2C2_2 |= (0x1UL << 10U);
// Set the number byte to send
Start_I2C(Number_Byte_Read);
}

// read RXNE status and return RXDR
unsigned char Read_Byte(void)
{
while(!(STATUS_REG_I2C2 & (0x1UL << 2U))){};
return READ_I2C2;
}

// Read register address value
uint8_t Read_Register(long Register_Address)
{
Start_Write(1);
Transmit_Byte(Register_Address);
Start_Read(1);
uint8_t Received_Byte = Read_Byte();
Stop_I2C();
return Received_Byte;
}

// calclaute register address value MSB and LSB
short Value_Register(unsigned char Address_Read)
{
short result ;
result = Read_Register(Address_Read) << 8U | Read_Register(Address_Read);
return result / 1000;
}

//retun the final value of register
void Output_Value(volatile short* Read_Value)
{
// Read the address value
*Read_Value = Value_Register(0x00UL);
}

// Sets up the entire I2c2 device system
void Init_I2C(void)
{
// Reset clock control GPIOB enable
AHB                 |= (0x1UL << 19U);
// Reset clock control I2C2 enable
APB                 |= (0x1UL << 22U);
// PIN 11 & PIN 13  Alternate function mode 10 Note if we use a hex number we can call MODER once
MODB                 |= (0x1UL << 23U) | (0x1UL << 27U);
MODB                 &= ~(0x1UL << 22U)| (0x1UL << 26U);
// Output open-drain pin 11 & 13 set to 1 
OTYB                 |= (0x1UL << 11U )| (0x1UL << 13U);
// Pull-up pin 11 & 13  Note if we use a hex number we can call PUPDR once
PUPB                 |= (0x1UL << 22U) | (0x1UL << 26U);
PUPB                 &= (0x1UL << 23U) | (0x1UL << 27U);
// I2C2_SDA pin 11 I2C2_SCL pin 13
ALTERNATE_FUNCB_1      |= (0x1UL << 12)  | (0x5UL << 20);
// I2C TIMING
TIMER_REG           |= 0x10402f13UL;
// CR1 ENABLE
CONTROL_REG_I2C2_1       |= (0x1UL << 0U);
// Set savle ID and left shif by 1
CONTROL_REG_I2C2_2       |= (0x24UL << 1U);
}

#include "i2c.h"
#include "registers.h"

void Start_I2C(int Number_Byte)
{

CONTROL_REG_I2C2_2 &= ~(0xFF<<16);//number of bytes to transmit = 1
CONTROL_REG_I2C2_2 |= (Number_Byte<<16)| I2C_CR2_START;//number of bytes to transmit = 1
while(CONTROL_REG_I2C2_2 &( 0x1UL << 13U)){}; //0x2000UL

}

void Stop_I2C(void)
{
CONTROL_REG_I2C2_2 |= (0x1UL << 14U);    ///0x4000UL
while(CONTROL_REG_I2C2_2 & (0x1UL << 14U)){}; //0x4000UL
}


void Start_Write(int Number_Byte_Write)
{
CONTROL_REG_I2C2_2 &= ~(0x1UL << 10U);   //0x400UL
Start_I2C(Number_Byte_Write);
}

void Transmit_Byte(uint16_t Byte_Transmit)
{
TRANSMIT_DATA = Byte_Transmit;
while(!(STATUS_REG_I2C2 & (0x1UL << 0U))){};  //0x01UL
}

void Start_Read(int Number_Byte_Read)
{
CONTROL_REG_I2C2_2 |= (0x1UL << 10U); // read operation 0x400UL
Start_I2C(Number_Byte_Read);
}
unsigned char Read_Byte(void)
{
while(!(STATUS_REG_I2C2 & (0x1UL << 2U))){};  //0x04UL
return READ_I2C2;
}
uint8_t Read_Register(long Register_Address)
{
Start_Write(1);
Transmit_Byte(Register_Address);
Start_Read(1);
uint8_t Received_Byte = Read_Byte();
Stop_I2C();
return Received_Byte;
}

short Value_Register(unsigned char Address_Read)
{
short result ;
result = Read_Register(Address_Read) << 8U | Read_Register(Address_Read);
return result / 1000;
}

void Output_Value(volatile short* Read_Value)
{
*Read_Value = Value_Register(0x00UL);
}

// initial i2c
void Init_I2C(void)
{
AHB                 |= (0x1UL << 19U);                           //RCC_AHBENR AND GPIOB   0x40000UL
APB                 |= (0x1UL << 22U);                           //RCC APB1ENR AND I2C        0x400000UL
MODB                 |= (0x1UL << 23U) | (0x1UL << 27U);          //PIBOB MODER PIN 11  Alternate function mode 10 &  //PIBOB MODER PIN 13  Alternate function mode 10 0x800000UL | 0x8000000UL
MODB                 &= ~(0x1UL << 22U)| (0x1UL << 26U);          //PIBOB MODER PIN 11  Alternate function mode 10 &  //PIBOB MODER PIN 13  Alternate function mode 10 
OTYB                 |= (0x1UL << 11U )| (0x1UL << 13U);          //Output open-drain pin 11 & 13 set to 1  0x800UL | 0x2000UL
PUPB                 |= (0x1UL << 22U) | (0x1UL << 26U);          //Pull-up pin 11 & 13 Pull-up 01:    0x100000UL | 0x1000000UL
PUPB                 &= (0x1UL << 23U) | (0x1UL << 27U);          //Pull-up pin 11 & 13 Pull-up 01:   
ALTERNATE_FUNCB_1      |= (0x1UL << 12)  | (0x5UL << 20);           //I2C2_SDA pin 11 I2C2_SCL pin 13   0x1000UL 0x500000UL
TIMER_REG           |= 0x10402f13UL;                             //I2C TIMING
CONTROL_REG_I2C2_1       |= (0x1UL << 0U);                            //CR1 ENABLE     0x01UL
CONTROL_REG_I2C2_2       |= (0x24UL << 1U);                           //savle address in CR2  0x48UL
}

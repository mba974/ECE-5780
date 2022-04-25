#include "i2c.h"
#include "registers.h"

void Start_I2C(int Number_Byte)
{
CONTROL_REG_2&= ~(0xFF0000UL);
CONTROL_REG_2|= (Number_Byte << 16);
CONTROL_REG_2 |= 0x2000UL;
while(CONTROL_REG_2 & 0x2000UL){};
}

void Stop_I2C(void)
{
CONTROL_REG_2 |= 0x4000UL;
while(CONTROL_REG_2 & 0x4000UL){};
}


void Start_Write(int Number_Byte_Write)
{
CONTROL_REG_2 &= ~(0x400UL);
Start_I2C(Number_Byte_Write);
}

void Transmit_Byte(uint8_t Byte_Transmit)
{
TRANSMIT_DATA = Byte_Transmit;
while(!(STATUS_REG & 0x01UL)){};
}

void Start_Read(int Number_Byte_Read)
{
CONTROL_REG_2 |= 0x400UL; // read operation
Start_I2C(Number_Byte_Read);
}

unsigned char Read_Byte(void)
{
while(!(STATUS_REG & 0x04UL)){};
return RECEIVED_DATA;
}


uint8_t Read_Register(uint8_t Register_Address)
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

result = Read_Register(Address_Read) << 8 | Read_Register(Address_Read);
return result / 1000;
}

void Output_Value(volatile short* Read_Value)
{
  *Read_Value = Value_Register(0x00);
}


void Init_I2C(void)
{
AHB                 |= 0x40000UL;                    //RCC_AHBENR AND GPIOB
APB                 |= 0x400000UL;                   //RCC APB1ENR AND I2C
MOD                 |= 0x800000UL | 0x8000000UL;     //PIBOB MODER PIN 11  Alternate function mode 10 &  //PIBOB MODER PIN 13  Alternate function mode 10
OTY                 |= 0x800UL | 0x2000UL;           // Output open-drain pin 11 & 13 set to 1
PUP                 |= 0x100000UL | 0x1000000UL;     // 	Pull-up pin 11 & 13 Pull-up 01:
ALTERNATE_FUNC      |= (0x1000UL);                   //I2C2_SDA pin 11
ALTERNATE_FUNC      |= (0x500000UL);                 //I2C2_SCL pin 13
TIMER_REG           |= (0x10402f13UL); 
CONTROL_REG_1       |= (0x01UL);                     //CR1 ENABLE
CONTROL_REG_2       |= 0x48UL;                       //savle address
}

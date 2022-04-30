#include "usart.h"
#include "registers.h"

volatile char Word = 0;

void Transmit_USART(int16_t Value_Transmit)
{
char buffer[64];
snprintf(buffer,64,"%d",Value_Transmit);
int i = 0;
while (buffer[i] != '\0') {
while (!(STATUS_REG_SERIAL3 & (0x1UL <<7U))){};
SEND_SERIAL3  = buffer[i++];
}
}



void SEND_MESSAGE(char *Get_String)
{
while (*Get_String) {
while (!(STATUS_REG_SERIAL3 & (0x1UL <<7U)));
SEND_SERIAL3 = *Get_String++;
}
}

uint8_t Read_USART(void)
{
while (!(STATUS_REG_SERIAL3 & (0x1UL << 5U)));  
return ((uint8_t)(READ_SERIAL3 & 0xFFUL));
}

void USART3_4_IRQHandler(void)
{
Word = 0;
Word = Read_USART();

if(Word <= 0x64)
{
target_rpm = Word;
Word = 0;
}

if((Word >= 0x65 )&& (Word <=0x6F))
{
Ki = Word - 0x65;
Word = 0;
}

if((Word >= 0x70 )&& (Word <=0x7A))
{
Kp = Word - 0x70;
Word = 0;
}

if(Word == 0x7B )
{
Direction =  0x0;
Word = 0;
}

if(Word == 124 )
{
Direction =  0x1;
Word = 0;
}

if(Word == 125 )
{
Direction =  0x2;
Word = 0;
}

if(Word == 126 )
{
NVIC_SystemReset();
Word = 0;
}

}

void Init_USART(void)
{
AHB |= (0x1UL << 19U);
APB |= (0x1UL << 18U);
BAUDRATE_SERIAL3 = 8000000/115200;
CONTROL_REG_USART_3_1 |= (0x1UL << 3U);
CONTROL_REG_USART_3_1 |= (0x1UL << 2U);
CONTROL_REG_USART_3_1 |=(0x1UL << 0U);
CONTROL_REG_USART_3_1 |= (0x1UL << 5U);
MODC |= (0x1UL << 9U) | (0x1UL << 11U);
MODC &= ~(0x1UL << 8U) | (0x1UL << 10U);
ALTERNATE_FUNCC |= (0x1UL << 16U) | (0x1UL << 20U);
NVIC_EnableIRQ(USART3_4_IRQn);
}
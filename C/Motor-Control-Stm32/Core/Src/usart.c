#include "usart.h"
#include "registers.h"
#include "motor.h"
/* 
-----------------------------------------------------------------------------------
--------------------------
 *  USART and Initialization Functions and Internal-Use Initialization Functions
 * 
-----------------------------------------------------------------------------------
--------------------------
 */
// Read data receive in usart  
volatile char Word = 0;

// Transmit integer usart
void Transmit_USART(int32_t Value_Transmit)
{
char buffer[64];
snprintf(buffer,64,"%d",Value_Transmit);
int i = 0;
while (buffer[i] != '\0') {
while (!(STATUS_REG_SERIAL3 & (0x1UL <<7U))){};

	SEND_SERIAL3  = buffer[i++];
}
}

// Transmit string usart
void SEND_MESSAGE(char *Get_String)
{
while (*Get_String) {
while (!(STATUS_REG_SERIAL3 & (0x1UL <<7U)));
SEND_SERIAL3 = *Get_String++;
}
}

// Read data incomeing 
uint8_t Read_USART(void)
{
while (!(STATUS_REG_SERIAL3 & (0x1UL << 5U)));  
return ((uint8_t)(READ_SERIAL3 & 0xFFUL));
}

// Usart interrupt to calculate to read in data from usart
/* 0-100 set target-motor value
* 101-111 set KI value
* 112-122 set KP value
* 123 set motor direction to right
* 124 set motor direction to left
* 125 set motor direction to unable
* 126 Reset the STM32
*/
void USART3_4_IRQHandler(void)
{
// Init variable 
Word = 0;
// Read in coming data
Word = Read_USART();
// 0-100 set target-motor value
if(Word <= 0x64)
{
Target_Rpm = Word;
Word = 0;
}
// 101-111 set KI value
if((Word >= 0x65 )&& (Word <=0x6F))
{
Ki = Word - 0x65;
Word = 0;
}
// 112-122 set KP value
if((Word >= 0x70 )&& (Word <=0x7A))
{
Kp = Word - 0x70;
Word = 0;
}
// 123 set motor direction to right
if(Word == 0x7B )
{
Direction =  0x0;
Word = 0;
}
// 124 set motor direction to left
if(Word == 124 )
{
Direction =  0x1;
Word = 0;
}
// 125 set motor direction to unable
if(Word == 125 )
{
Direction =  0x2;
Word = 0;
}
// 126 Reset the STM32
if(Word == 126 )
{
NVIC_SystemReset();
Word = 0;
}
}

//Init the usart
void Init_USART(void)
{
// Init hal
// enable clock GPIOC
HAL_Init();
//// enable clock GPIOC
AHB                    |= (0x1UL << 19U);
// enable clock USART-3
APB                    |= (0x1UL << 18U);
// set USART baudate
BAUDRATE_SERIAL3       = 8000000/115200;
// Usart-3 control register
CONTROL_REG_USART_3_1  |= (0x1UL << 3U);
CONTROL_REG_USART_3_1  |= (0x1UL << 2U);
CONTROL_REG_USART_3_1  |=(0x1UL << 0U);
CONTROL_REG_USART_3_1  |= (0x1UL << 5U);
// Moder for usart pins 4 & 5
MODC                   |= (0x1UL << 9U) | (0x1UL << 11U);
MODC                   &= ~(0x1UL << 8U) | (0x1UL << 10U);
// Set pin 4 & 5 RX & TX
ALTERNATE_FUNCC_0      |= (0x1UL << 16U) | (0x1UL << 20U);
// Enable interrupt in NVIC 
NVIC_EnableIRQ(USART3_4_IRQn);
}

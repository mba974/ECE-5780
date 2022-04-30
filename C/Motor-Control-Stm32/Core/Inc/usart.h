#ifndef USART_H_
#define USART_H_

#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

extern volatile char Word;
void Transmit_USART(int16_t Value_Transmit);
void Init_USART(void);
void SEND_MESSAGE(char *Get_String);
uint8_t Read_USART(void);
#endif

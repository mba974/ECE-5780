#ifndef USART_H_
#define USART_H_

#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

extern volatile char Word;
void USART_TRANSMIT(int16_t Number);
void usart_Init(void);
void SEND_MESSAGE(char *GetChar);
uint8_t USART_READ(void);
#endif

#ifndef USART_H_
#define USART_H_

#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

/* -------------------------------------------------------------------------------------------------------------
 *  Motor Control and Initialization Functions
 * -------------------------------------------------------------------------------------------------------------
 */
// Read data receive in usart  
extern volatile char Word;
// Transmit integer usart
void Transmit_USART(int32_t Value_Transmit);
//Init the usart
void Init_USART(void);
// Transmit string usart
void SEND_MESSAGE(char *Get_String);
// Read data incomeing
uint8_t Read_USART(void);

#endif

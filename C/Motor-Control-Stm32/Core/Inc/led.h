#ifndef LED_H_
#define LED_H_
#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

extern volatile short Angle_Degrees;
extern volatile short Convert_Value;

void Init_LED(void);
void LED(void);
#endif

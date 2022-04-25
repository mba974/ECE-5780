#ifndef LED_H_
#define LED_H_
#include <stdio.h>
#include <stdlib.h>
#include "stm32f0xx.h"

extern  volatile short OutX   ;    // Speed error signal
extern volatile  short OutY  ;        // Proportional gain
extern volatile  long count  ;        // Proportional gain

void led_init(void);
void led(void);
#endif

#ifndef REGISTERS_H_
#define REGISTERS_H_

#define  UNIQUE_DEVICE_ID        0x1FFFF7ACUL 
#define PORT_A                   0x48000000UL
#define PORT_B                   0x48000400UL
#define PORT_C                   0x48000800UL
#define I2C_2                    0x40005800UL
#define SERIAL_PORT_3            0x40004800UL
#define RESET_CONTROL            0x40021000UL
#define TIM_3                    0x40000400UL
#define TIM_6                    0x40001000UL
#define TIM_14                   0x40002000UL

/*PORT_A----------------------------------------------------------*/
#define MODA                     (*(volatile unsigned *) (PORT_A + 0x00UL))
#define OTYA                     (*(volatile unsigned *) (PORT_A + 0x04UL))
#define OSPA                     (*(volatile unsigned *) (PORT_A + 0x08UL))
#define PUPA                     (*(volatile unsigned *) (PORT_A + 0x0CUL))
#define ALTERNATE_FUNCA_0        (*(volatile unsigned *) (PORT_A + 0x20UL))
#define OUTPUT_PORTA             (*(volatile unsigned *) (PORT_A + 0x14UL))
/*PORT_B----------------------------------------------------------*/
#define MODB                     (*(volatile unsigned *) (PORT_B + 0x00UL))
#define OTYB                     (*(volatile unsigned *) (PORT_B + 0x04UL))
#define PUPB                     (*(volatile unsigned *) (PORT_B + 0x0CUL))
#define ALTERNATE_FUNCB_0        (*(volatile unsigned *) (PORT_B + 0x20UL))
#define ALTERNATE_FUNCB_1        (*(volatile unsigned *) (PORT_B + 0x24UL))
/*PORT_C----------------------------------------------------------*/
#define MODC                     (*(volatile unsigned *) (PORT_C + 0x00UL))
#define OTYC                     (*(volatile unsigned *) (PORT_C + 0x04UL))
#define OSPC                     (*(volatile unsigned *) (PORT_C + 0x08UL))
#define PUPC                     (*(volatile unsigned *) (PORT_C + 0x0CUL))
#define ALTERNATE_FUNCC_0        (*(volatile unsigned *) (PORT_C + 0x20UL))
#define OUTPUT_PORTC             (*(volatile unsigned *) (PORT_C + 0x14UL))

/*I2C------------------------------------------------------------*/
#define CONTROL_REG_I2C2_1       (*(volatile unsigned *) (I2C_2 + 0x00UL))
#define CONTROL_REG_I2C2_2       (*(volatile unsigned *) (I2C_2 + 0x04UL))
#define TIMER_REG                (*(volatile unsigned *) (I2C_2 + 0x10UL))
#define STATUS_REG_I2C2          (*(volatile unsigned *) (I2C_2 + 0x18UL))
#define READ_I2C2                (*(volatile unsigned *) (I2C_2 + 0x24UL))
#define TRANSMIT_DATA            (*(volatile unsigned *) (I2C_2 + 0x28UL))

/*SERIAL_PORT_3------------------------------------------------------------*/
#define CONTROL_REG_USART_3_1    (*(volatile unsigned *) (SERIAL_PORT_3 + 0x00UL))
#define READ_SERIAL3             (*(volatile unsigned *) (SERIAL_PORT_3 + 0x24UL))
#define SEND_SERIAL3             (*(volatile unsigned *) (SERIAL_PORT_3 + 0x28UL))
#define STATUS_REG_SERIAL3       (*(volatile unsigned *) (SERIAL_PORT_3 + 0x1CUL))
#define BAUDRATE_SERIAL3         (*(volatile unsigned *) (SERIAL_PORT_3 + 0x0CUL))
/*TIM_3------------------------------------------------------------*/
#define CONTROL_REG_TIM_3_1      (*(volatile unsigned *) (TIM_3 + 0x00UL))
#define SLAVE_MOD_REG_TIM_3      (*(volatile unsigned *) (TIM_3 + 0x08UL)) 
#define COM_MOD_REG_TIM_3_1      (*(volatile unsigned *) (TIM_3 + 0x18UL))
#define COM_ENB_REG_TIM_3_1      (*(volatile unsigned *) (TIM_3 + 0x20UL))
#define PRESCALER_TIM_3          (*(volatile unsigned *) (TIM_3 + 0x28UL))
#define RELOAD_REG_TIM_3         (*(volatile unsigned *) (TIM_3 + 0x2CUL))
#define COM_REG_TIM_3            (*(volatile unsigned *) (TIM_3 + 0x34UL))
#define COUNTER_TIM_3            (*(volatile unsigned *) (TIM_3 + 0x24UL))
/*TIM_6------------------------------------------------------------*/
#define CONTROL_REG_TIM_6_1      (*(volatile unsigned *) (TIM_6 + 0x00UL))
#define COM_MOD_REG_TIM_6_1      (*(volatile unsigned *) (TIM_6 + 0x18UL))
#define COM_ENB_REG_TIM_6_1      (*(volatile unsigned *) (TIM_6 + 0x20UL))
#define PRESCALER_TIM_6          (*(volatile unsigned *) (TIM_6 + 0x28UL))
#define RELOAD_REG_TIM_6         (*(volatile unsigned *) (TIM_6 + 0x2CUL))
#define COM_REG_TIM_6            (*(volatile unsigned *) (TIM_6 + 0x34UL))
#define I_ENB_REG_TIM_6          (*(volatile unsigned *) (TIM_6 + 0x0CUL))
#define STATUS_REG_TIM_6         (*(volatile unsigned *) (TIM_6 + 0x10UL))
/*TIM_14------------------------------------------------------------*/
#define CONTROL_REG_TIM_14_1     (*(volatile unsigned *) (TIM_14 + 0x00UL))
#define COM_MOD_REG_TIM_14_1     (*(volatile unsigned *) (TIM_14 + 0x18UL))
#define COM_ENB_REG_TIM_14_1     (*(volatile unsigned *) (TIM_14 + 0x20UL))
#define PRESCALER_TIM_14         (*(volatile unsigned *) (TIM_14 + 0x28UL))
#define RELOAD_REG_TIM_14        (*(volatile unsigned *) (TIM_14 + 0x2CUL))
#define COM_REG_TIM_14           (*(volatile unsigned *) (TIM_14 + 0x34UL))



/*RESET_CONTROL--------------------------------------------------*/
#define AHB                      (*(volatile unsigned *) (RESET_CONTROL+0x14UL))  // AHBENR
#define APB                      (*(volatile unsigned *) (RESET_CONTROL+0x1CUL))  // APB1ENR

#endif

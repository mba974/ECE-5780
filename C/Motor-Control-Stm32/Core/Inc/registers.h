#ifndef REGISTERS_H_
#define REGISTERS_H_


#define PIN_B              0x48000400UL
#define PIN_C             0x48000800UL
#define I2C2               0x40005800UL
#define SERIAL_PORT_3      0x40004800UL
#define RESET_CONTROL      0x40021000UL


/*PIN_B----------------------------------------------------------*/
#define MODB                  (*(volatile unsigned *) (PIN_B + 0x00UL))
#define OTYB                  (*(volatile unsigned *) (PIN_B + 0x04UL))
#define PUPB                  (*(volatile unsigned *) (PIN_B + 0x0CUL))
#define ALTERNATE_FUNCB       (*(volatile unsigned *) (PIN_B + 0x24UL))

/*PIN_B----------------------------------------------------------*/
#define MODC                  (*(volatile unsigned *) (PIN_C + 0x00UL))
#define OTYC                  (*(volatile unsigned *) (PIN_C + 0x04UL))
#define PUPC                  (*(volatile unsigned *) (PIN_C + 0x0CUL))
#define ALTERNATE_FUNCC       (*(volatile unsigned *) (PIN_C + 0x24UL))

/*I2C------------------------------------------------------------*/
#define CONTROL_REG_I2C2_1    (*(volatile unsigned *) (I2C2 + 0x00UL))
#define CONTROL_REG_I2C2_2    (*(volatile unsigned *) (I2C2 + 0x04UL))
#define TIMER_REG            (*(volatile unsigned *) (I2C2 + 0x10UL))
#define STATUS_REG_I2C2       (*(volatile unsigned *) (I2C2 + 0x18UL))
#define READ_I2C2        (*(volatile unsigned *) (I2C2 + 0x24UL))
#define TRANSMIT_DATA        (*(volatile unsigned *) (I2C2 + 0x28UL))

/*SERIAL_PORT_3------------------------------------------------------------*/
#define CONTROL_REG_USART_3_1    (*(volatile unsigned *) (SERIAL_PORT_3 + 0x00UL))
#define READ_SERIAL3             (*(volatile unsigned *) (SERIAL_PORT_3 + 0x24UL))
#define SEND_SERIAL3             (*(volatile unsigned *) (SERIAL_PORT_3 + 0x28UL))
#define STATUS_REG_SERIAL3       (*(volatile unsigned *) (SERIAL_PORT_3 + 0x1CUL))
#define BAUDRATE_SERIAL3         (*(volatile unsigned *) (SERIAL_PORT_3 + 0x0CUL))


/*RESET_CONTROL--------------------------------------------------*/
#define AHB                  (*(volatile unsigned *) (RESET_CONTROL+0x14UL))  // AHBENR
#define APB                  (*(volatile unsigned *) (RESET_CONTROL+0x1CUL))  // APB1ENR

#endif

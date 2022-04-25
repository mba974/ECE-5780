#ifndef REGISTERS_H_
#define REGISTERS_H_


#define PIN_B             0x48000400UL
#define I2C               0x40005800UL
#define RESET_CONTROL     0x40021000UL

#define MOD              (*(volatile unsigned *) (PIN_B + 0x00UL))
#define OTY              (*(volatile unsigned *) (PIN_B + 0x04UL))
#define PUP              (*(volatile unsigned *) (PIN_B + 0x0CUL))
#define ALTERNATE_FUNC   (*(volatile unsigned *) (PIN_B + 0x24UL))

#define CONTROL_REG_1    (*(volatile unsigned *) (I2C + 0x00UL))
#define CONTROL_REG_2    (*(volatile unsigned *) (I2C + 0x04UL))
#define TIMER_REG        (*(volatile unsigned *) (I2C + 0x10UL))
#define STATUS_REG       (*(volatile unsigned *) (I2C + 0x18UL))
#define RECEIVED_DATA    (*(volatile unsigned *) (I2C + 0x24UL))
#define TRANSMIT_DATA    (*(volatile unsigned *) (I2C + 0x28UL))

#define AHB   					 (*(volatile unsigned *) (RESET_CONTROL+0x14UL))  // AHBENR
#define APB  						 (*(volatile unsigned *) (RESET_CONTROL+0x1CUL))  // APB1ENR

#endif

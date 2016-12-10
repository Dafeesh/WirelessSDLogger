#ifndef _DEVICECORE_H_
#define _DEVICECORE_H_

#if defined(ARDUINO) && ARDUINO >= 100
#include "Arduino.h"
#else
#include "WProgram.h"
#endif

#include "Pins.h"

//#include <avr/pgmspace.h>
#include <SoftwareSerial.h>

//#define USE_LINE_SERIAL
#define USE_PROXY_SERIAL
#define USE_SD
//#define EXAMPLE_INPUTS
#define SERIAL_BAUD		9600
#define SEND_PACKET_RATE 20

#ifdef USE_PROXY_SERIAL
extern SoftwareSerial proxySerial;
#endif

#if defined(USE_LINE_SERIAL)
#define debugPrint(x) Serial.print(x)
#define debugPrintln(x) Serial.println(x)
#elif defined(USE_PROXY_SERIAL)
#define debugPrint(x) proxySerial.print(x)
#define debugPrintln(x) proxySerial.println(x)
#else
#define debugPrint(x) 
#define debugPrintln(x)  
#endif

void deviceSetup(void);
void toggleLED(bool toggle);
void toggleGuardDog(bool toggle);
void criticalError(const char* str);
const char* progmem_string(const char* progmem_str);

#endif

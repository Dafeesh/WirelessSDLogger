
#include "DeviceCore.h"

#define PROGMEM_CACHE_SIZE 4
#define PROGMEM_CACHE_LEN 40

#ifdef USE_PROXY_SERIAL
SoftwareSerial proxySerial(PIN_PROXYSERIAL_RX, PIN_PROXYSERIAL_TX);
#endif

int progmem_iter = 0;
char progmem_cached[PROGMEM_CACHE_SIZE][PROGMEM_CACHE_LEN];

void deviceSetup(void)
{
	//pinMode(PIN_LED_YELLOW, OUTPUT);
	pinMode(PIN_ANALOG_A, INPUT);
	pinMode(PIN_ANALOG_B, INPUT);
	pinMode(PIN_SWITCH, INPUT);

#ifdef USE_PROXY_SERIAL
	proxySerial.begin(SERIAL_BAUD);
	delay(1000);
	debugPrint(F("Proxy baud: "));
	debugPrintln(SERIAL_BAUD);
#endif

	Serial.begin(SERIAL_BAUD);
	debugPrint(F("Serial baud: "));
	debugPrintln(SERIAL_BAUD);
}

void toggleLED(bool toggle)
{
	//digitalWrite(PIN_LED_YELLOW, toggle ? HIGH : LOW);
}

void toggleGuardDog(bool toggle)
{
	digitalWrite(PIN_GUARDDOG, toggle ? HIGH : LOW);
}

void criticalError(const char* str)
{
	while (1) {
		digitalWrite(PIN_LED_YELLOW, HIGH);
		Serial.println(str);
		delay(500);
		digitalWrite(PIN_LED_YELLOW, LOW);
		delay(500);
	}
}


const char* progmem_string(const char* progmem_str)
{
	char c;
	int len = strlen_P(progmem_str);
	if (len + 1 >= PROGMEM_CACHE_LEN)
		criticalError((const char*)F("ERR: Progmem overflow"));

	progmem_iter += 1;
	if (progmem_iter >= PROGMEM_CACHE_SIZE)
		progmem_iter = 0;

	for (int i = 0; i <= len; i++)
	{
		if (i != len)
			progmem_cached[progmem_iter][i] = (char)pgm_read_byte(progmem_str + i);
		else
			progmem_cached[progmem_iter][i] = '\0';
	}

	return progmem_cached[progmem_iter];
}
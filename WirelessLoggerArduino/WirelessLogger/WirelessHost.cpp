// 
// 
// 

#include "WirelessHost.h"
#include "DeviceCore.h"

#define SEND_RATE_DELAY_HALF ((unsigned long)(1000 / (SEND_PACKET_RATE / 2)))

#define sendString(x) { Serial.print(x); debugPrint(x); }
#define sendFlush() { Serial.flush(); debugPrintln(); }

const char _WIFI_AP_NAME[] PROGMEM = "WirelessLogger_UCF1";
#define WIFI_AP_NAME progmem_string(_WIFI_AP_NAME)
const char _WIFI_AP_PASS[] PROGMEM = "123ucf456";
#define WIFI_AP_PASS progmem_string(_WIFI_AP_PASS)
const uint8_t WIFI_AP_PORT = 52017;

WirelessHost::WirelessHost()
{ }

bool WirelessHost::Start()
{
	return true;
}

void WirelessHost::Close()
{

}

void WirelessHost::ClearIncoming()
{
	while (Serial.available()) {
		Serial.read();
		delay(1);
	}
	//Serial.clearWriteError();
}

Cmd WirelessHost::ListenForCommand()
{
	if (Serial.available())
	{
		while (Serial.available()) {
			receive_cmd_buffer[2] = receive_cmd_buffer[1];
			receive_cmd_buffer[1] = receive_cmd_buffer[0];
			receive_cmd_buffer[0] = (char)Serial.read();
			if (receive_cmd_buffer[0] == receive_cmd_buffer[1] &&
				receive_cmd_buffer[1] == receive_cmd_buffer[2])
			{
				switch (receive_cmd_buffer[0]) {
				case ((char)Cmd::DeleteAll):
					debugPrintln(F("Read cmd: delete all"));
					return Cmd::DeleteAll;
				case ((char)Cmd::ResendFill):
					debugPrintln(F("Read cmd: resend"));
					return Cmd::ResendFill;
				}
			}
		}
	}
	return Cmd::Null;
}

bool WirelessHost::SendCmd(Cmd cmd)
{
	char snd[4] = { (char)cmd , (char)cmd , (char)cmd, '\0' };

	sendString(snd);
	return true;
}

bool WirelessHost::SendString(const char *str)
{
	sendString(str);
	return true;
}

void WirelessHost::SendFlush()
{
	delay(SEND_RATE_DELAY_HALF);
	sendFlush();
	delay(SEND_RATE_DELAY_HALF);
}
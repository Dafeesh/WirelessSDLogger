// WirelessHost.h

#ifndef _WIRELESSHOST_H_
#define _WIRELESSHOST_H_

#include "DeviceCore.h"

#define RECEIVE_CMD_LEN 3

enum class Cmd {
	Null = 0,
	DeleteAll = '!',

	Update_Front = '<',
	Update_Tail = '>',

	FillEntry_Front = '(',
	FillEntry_Tail = ')',

	ResendFill = '&'
};

class WirelessHost {
public:
	WirelessHost();

	bool Start();
	void Close();

	void ClearIncoming();
	Cmd ListenForCommand();
	bool SendString(const char *str);
	bool SendCmd(Cmd cmd);
	void SendFlush();

private:
	char receive_cmd_buffer[RECEIVE_CMD_LEN];
};

#endif


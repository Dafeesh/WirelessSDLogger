/*
 Name:		WirelessLogger.ino
 Created:	10/20/2016 10:54:06 AM
 Author:	Blake Scherschel
*/
bool ___initfile;

#include "SDLogger.h"
#include "WirelessHost.h"
#include "DeviceCore.h"

// Libraries
//#include <avr/pgmspace.h>
#include <SPI.h>
#include <SdFat.h>
#include <SoftwareSerial.h>
// ~

SDLogger logger;
WirelessHost wifi;

int n = 0;
DataEntry dat;
Cmd cmd;

void deleteAllLogs();
void sendSingleLog(DataEntry de);
void sendFillEntry(FillEntry fe);
void sendFillOn();
void sendFillOff();
void sendGuardOn();
void sendGuardOff();

////////////////////////////////////////////
////////////////////////////////////////////
////////////////////////////////////////////
// Changeable area

// Use for logging:
//	logger.Log(valueA, valueB);
// or
//	logger.Log(valueA, valueB, trigger);

bool triggeredSwitch = false;
bool flowStartSwitch = false;
int flowCycleNumber = 0;
int flowLeakCycleCount = 0;

int flowSampleCount = 0;
uint64_t flowSampleStartTime = 0;
uint64_t flowSampleEndTime = 0;
float flowSampleTimeTotal = 0;
uint64_t flowSampleValueATotal = 0;
uint64_t flowSampleValueBTotal = 0;
uint64_t flowSampleValueDeltaTotal = 0;
int flowSampleAverageDeltaValue = 0;
int flowSampleUnderCount = 0;

int deltaValue;
const int deltaValueCritical = 100;		// High flow rate value in respect to delta pressure in analog value
const float sampleRate = 0.1f;			// Sample rate in seconds
const int flowTimeCritical = 10;		// Critical leak duration
const int leakCycleCountCritical = 2;	// Amount of low flow leaks that can occur
const int flowThreshold = 2;
const int sampleThreshold = 5;

long lastSendMillis = 0;
bool flowToggle = false;
bool guardToggle = false;

void handleLogic(bool trigger, int valueA, int valueB)
{
	deltaValue = valueB - valueA;
	if (millis() - lastSendMillis > 500) {
		sendSingleLog(logger.GenerateDataEntry(valueA, valueB, flowToggle, guardToggle));
		lastSendMillis = millis();
	}

	if (trigger == true && triggeredSwitch == false)
	{
		triggeredSwitch = true;	//Signals that a flush was activated
		flowLeakCycleCount = 0;	//Resets leak count

		toggleGuardDog(true);
		sendGuardOn();

		debugPrintln(F("Triggered flipped"));
	}

	// Is positive flow?
	if (deltaValue > flowThreshold)
	{
		if (flowStartSwitch == false)
		{
			flowStartSwitch = true;
			flowCycleNumber += 1;

			// Reset sampling variables to zero
			flowSampleCount = 0;
			flowSampleValueATotal = 0;
			flowSampleValueBTotal = 0;
			flowSampleValueDeltaTotal = 0;
			flowSampleStartTime = millis();
			flowSampleEndTime = 0;
			flowSampleUnderCount = 0;

			sendFillOn();
			debugPrintln(F("Flow start"));
		}

		// Record sample
		flowSampleCount += 1;
		flowSampleUnderCount = 0;
		flowSampleTimeTotal = millis() - flowSampleStartTime;
		flowSampleValueATotal += valueA;
		flowSampleValueBTotal += valueB;
		flowSampleValueDeltaTotal += deltaValue;

		flowSampleAverageDeltaValue = (int)((float)flowSampleValueDeltaTotal / flowSampleCount);

		// Print to serial
		debugPrint(F("Log: A[ "));
		debugPrint(valueA);
		debugPrint(F(" ] B[ "));
		debugPrint(valueB);
		debugPrintln(F(" ]"));

		// Check if any limits have been met without a trigger
		if (triggeredSwitch == false)
		{
			// If a high flow rate occurs for long time
			if (flowSampleAverageDeltaValue >= deltaValueCritical
				&& (int)flowSampleTimeTotal >= flowTimeCritical)
			{
				toggleGuardDog(false);   // Closes Guard Dog valve via relay
				sendGuardOff();
				debugPrintln(F("Flow critical! Close guard."));
			}
		}
	}
	// Is zero or zero flow?
	else if (deltaValue <= 0)
	{
		// Recognizes end of fill cycle
		if (flowStartSwitch == true)
		{
			if (flowSampleUnderCount > sampleThreshold)
			{
				if (flowSampleCount > sampleThreshold)
				{
					flowStartSwitch = false;
					flowSampleEndTime = millis();

					FillEntry fe = FillEntry();
					fe.runId = logger.GetRunId();
					fe.startTime = flowSampleStartTime;
					fe.endTime = flowSampleEndTime;
					//fe.isTriggered
					fe.avgDeltaValue = flowSampleAverageDeltaValue;
					fe.avgValueA = flowSampleValueATotal / flowSampleCount;
					fe.avgValueB = flowSampleValueBTotal / flowSampleCount;

					// Was this end of fill cycle triggered?
					if (triggeredSwitch == true)
					{
						fe.isTriggered = true;
						triggeredSwitch = false;
						debugPrintln(F("End of triggered fill"));
					}
					else // If not, then it was a leak fill
					{
						fe.isTriggered = false;
						flowLeakCycleCount += 1;
						debugPrint(F("End of leak fill: "));
						debugPrintln(flowLeakCycleCount);

						// After 5 leaks with out flush, valve is closed
						if (flowLeakCycleCount >= leakCycleCountCritical)
						{
							toggleGuardDog(false);	// Closes Guard Dog valve via relay
							sendGuardOff();
							debugPrintln(F("Leak count critical! Close guard."));
						}
					}

					fe.fillId = flowLeakCycleCount;

					sendFillOff();
					sendFillEntry(fe);
					logger.LogFillEvent(fe);
					debugPrint(F("Entry: "));
					debugPrintln(fe.ToStringCSV().c_str());
				}
				else
				{
					flowStartSwitch = false;
					debugPrintln(F("Threw away noise"));
				}
			}
			else 
			{
				// Ignore if under threshold
				flowSampleUnderCount += 1;
			}
		}
	}
}


////////////////////////////////////////////
////////////////////////////////////////////
////////////////////////////////////////////
// GO BACK NOW

void setup() {
	deviceSetup();

	debugPrintln(F("--- Starting ---"));
	toggleLED(true);

	if (!logger.Start())
		criticalError((const char*)F("No SD logger"));
	else
		debugPrintln(F("SD started."));

	if (!wifi.Start())
		criticalError((const char*)F("No wifi module"));
	else
		debugPrintln(F("Wifi started."));

	debugPrint(F("Run Id: "));
	debugPrintln(logger.GetRunId());

	toggleLED(false);
	toggleGuardDog(true);
	sendGuardOn();
	sendFillOff();
	debugPrintln(F("--- READY ---"));
}

void loop() {
	int a1, a2, sw;
	unsigned long startTime;

	startTime = millis();

	a1 = analogRead(PIN_ANALOG_A);
	a2 = analogRead(PIN_ANALOG_B);
	sw = digitalRead(PIN_SWITCH);

	handleLogic(sw == HIGH, a1, a2);

	if (millis() - startTime < 100)
		delay(100 - (millis() - startTime));

	handleCommands();
}

void handleCommands() {
	cmd = wifi.ListenForCommand();
	switch (cmd) {
	case Cmd::DeleteAll:
		deleteAllLogs();
		break;
	case Cmd::ResendFill:
		sendFillEntry(logger.GetMostRecent());
		break;
	}
}

void deleteAllLogs() {
	logger.DeleteAll();
	wifi.SendCmd(Cmd::DeleteAll);
	wifi.SendFlush();
	wifi.ClearIncoming();
}

void sendSingleLog(DataEntry de) {
	wifi.SendCmd(Cmd::Update_Front);
	wifi.SendString(de.ToStringCSV().c_str());
	wifi.SendCmd(Cmd::Update_Tail);
	wifi.SendFlush();
}

void sendFillEntry(FillEntry fe) {
	int n = 3;
	for (int i = 0; i < n; i++) {
		delay(50);
		wifi.SendCmd(Cmd::FillEntry_Front);
		wifi.SendString(fe.ToStringCSV().c_str());
		wifi.SendCmd(Cmd::FillEntry_Tail);
		wifi.SendFlush();
	}
}

void sendFillOn() {
	//wifi.SendCmd(Cmd::FillingOn);
	//wifi.SendFlush();
	flowToggle = true;
}

void sendFillOff() {
	//wifi.SendCmd(Cmd::FillingOff);
	//wifi.SendFlush();
	flowToggle = false;
}

void sendGuardOn() {
	//wifi.SendCmd(Cmd::GuardOn);
	//wifi.SendFlush();
	guardToggle = true;
}

void sendGuardOff() {
	//wifi.SendCmd(Cmd::GuardOff);
	//wifi.SendFlush();
	guardToggle = false;
}

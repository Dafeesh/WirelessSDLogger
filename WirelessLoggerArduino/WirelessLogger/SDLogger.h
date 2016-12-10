// SDLogger.h

#ifndef _SDLOGGER_H_
#define _SDLOGGER_H_

#include "DeviceCore.h"
#include "WirelessHost.h"

#include <SPI.h>
#include <SdFat.h>

const uint8_t BUFFERED_ENTRIES_LEN = 8;
const uint8_t SEND_BUFFER_SIZE = 30;

struct FillEntry {
public:
	uint16_t runId;
	uint16_t fillId;

	uint64_t startTime;
	uint64_t endTime;

	bool isTriggered;
	uint16_t avgDeltaValue;
	uint16_t avgValueA;
	uint16_t avgValueB;

	FillEntry();
	~FillEntry();

	String ToStringCSV(void);
};

struct DataEntry {
public:
	uint16_t run_id;
	uint64_t relative_time;
	uint16_t sensor_value_a;
	uint16_t sensor_value_b;
	bool flow_toggle;
	bool guard_toggle;

	DataEntry() {}
	DataEntry(uint16_t run_id, uint64_t relativeTime, int sensorValueA, int sensorValueB, bool flowToggle, bool guardToggle);

	String ToStringCSV();
	void PrintDebug();
};

class SDLogger {
public:
	SDLogger();
	~SDLogger();

	bool Start();

	DataEntry GenerateDataEntry(
		uint16_t sensor_value_a,
		uint16_t sensor_value_b,
		bool flow_toggle,
		bool guard_toggle);
	void LogFillEvent(FillEntry fe);
	uint16_t GetRunId();
	FillEntry GetMostRecent();
	void DeleteAll();

private:
	void InitFile();
	void CloseFile();
	void Flush();
	void PushEntry(FillEntry fe);

	File _file;
	bool _is_active;
	uint16_t _run_id;
	FillEntry _lastEntry;
	FillEntry _entries[BUFFERED_ENTRIES_LEN];
	uint8_t _entries_index;
};

#endif


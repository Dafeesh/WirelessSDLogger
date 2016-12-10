// 
// 
// 

#include "SDLogger.h"

const static char _str_info_filename[] PROGMEM = "RunInfo.txt";
#define str_info_filename progmem_string(_str_info_filename)

const static char _str_log_filename[] PROGMEM = "Log.csv";
#define str_log_filename progmem_string(_str_log_filename)

static SdFat SD;

FillEntry::FillEntry(void)
{ }

FillEntry::~FillEntry(void)
{ }

String FillEntry::ToStringCSV(void)
{
	String str = "";
	str += runId;
	str += ',';
	str += fillId;
	str += ',';

	str += (unsigned long)startTime;
	str += ',';
	str += (unsigned long)endTime;
	str += ',';

	str += isTriggered ? 1 : 0;
	str += ',';
	str += avgDeltaValue;
	str += ',';
	str += avgValueA;
	str += ',';
	str += avgValueB;

	return str;
}

DataEntry::DataEntry(uint16_t runId, uint64_t relativeTime, int sensorValueA, int sensorValueB, bool flowToggle, bool guardToggle)
{
	run_id = runId;
	relative_time = relativeTime;
	sensor_value_a = sensorValueA;
	sensor_value_b = sensorValueB;
	flow_toggle = flowToggle;
	guard_toggle = guardToggle;
}

String DataEntry::ToStringCSV()
{
	String s;
	s += run_id;
	s += ',';
	s += (unsigned long)relative_time;
	s += ',';
	s += (int32_t)sensor_value_a;
	s += ',';
	s += (int32_t)sensor_value_b;
	s += ',';
	s += (int32_t)(flow_toggle ? 1 : 0);
	s += ',';
	s += (int32_t)(guard_toggle ? 1 : 0);
	return s;
}

void DataEntry::PrintDebug()
{
	debugPrint(F("< id["));
	debugPrint(run_id);
	debugPrint(F("] time["));
	debugPrint((unsigned long)relative_time);
	debugPrint(F("] a["));
	debugPrint(sensor_value_a);
	debugPrint(F("] b["));
	debugPrint(sensor_value_b);
	debugPrint(F("] />"));
}

SDLogger::SDLogger()
{
	_entries_index = 0;
}

SDLogger::~SDLogger()
{ }

FillEntry SDLogger::GetMostRecent() {
	return _lastEntry;
}

bool SDLogger::Start()
{
	debugPrintln(F("Starting SD.."));
	if (!SD.begin(PIN_SD_CS))
		return false;

	InitFile();

	return true;
}

void SDLogger::InitFile()
{
	//Retrieve and increase run id
	File f = SD.open(str_info_filename, FILE_WRITE);

	String runIdPrefix = String(F("runid="));
	if (f.size() < runIdPrefix.length() + 1) {
		f.seek(0);
		f.print(runIdPrefix.c_str());
		f.println("0;");
	}

	f.seek(runIdPrefix.length());
	_run_id = f.parseInt() + 1;

	f.seek(runIdPrefix.length());
	f.print(_run_id);
	f.println(';');

	f.flush();
	f.close();

	//Get log file ready
	_file = SD.open(str_log_filename, FILE_WRITE);
}

void SDLogger::CloseFile()
{
	Flush();
	_file.close();
}

DataEntry SDLogger::GenerateDataEntry(
	uint16_t sensor_value_a,
	uint16_t sensor_value_b,
	bool flow_toggle,
	bool guard_toggle)
{
	return DataEntry(GetRunId(), millis(), sensor_value_a, sensor_value_b, flow_toggle, guard_toggle);
}

void SDLogger::LogFillEvent(FillEntry fe)
{
	/*
	FillEntry fe;
	fe.runId = GetRunId();
	fe.fillId = fillId;
	fe.startTime = startTime;
	fe.endTime = endTime;
	fe.isTriggered = isTriggered;
	fe.avgDeltaValue = avgDeltaValue;
	fe.avgValueA = avgValueA;
	fe.avgValueB = avgValueB;
	*/

	_lastEntry = fe;
	_entries[_entries_index++] = fe;
	if (_entries_index >= BUFFERED_ENTRIES_LEN)
		Flush();
}

void SDLogger::Flush()
{
	for (int i = 0; i < _entries_index; i++) {
		PushEntry(_entries[i]);
	}
	_file.flush();
	_entries_index = 0;

	debugPrintln(F("SD Flush"));
}

void SDLogger::PushEntry(FillEntry fe)
{
	_file.println(fe.ToStringCSV());
}

uint16_t SDLogger::GetRunId()
{
	return _run_id;
}

void SDLogger::DeleteAll()
{
	CloseFile();
	SD.remove(str_log_filename);
	InitFile();
}
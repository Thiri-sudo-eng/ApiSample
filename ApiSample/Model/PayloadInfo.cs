using System;
using System.Collections.Generic;

namespace ApiSample.Model
{
    public class PayloadInfo
    {
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string DeviceName { get; set; }
        public string GroupId { get; set; }
        public string DataType { get; set; }
        public Int64 Timestamp { get; set; }
        public DataInfo Data { get; set; }
    }
    public class DataInfo
    {
        public bool FullPowerMode { get; set; }
        public bool ActivePowerControl { get; set; }
        public int FirmwareVersion { get; set; }
        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Version { get; set; }
        public string MessageType { get; set; }
        public bool Occupancy { get; set; }
        public int StateChanged { get; set; }
    }
}

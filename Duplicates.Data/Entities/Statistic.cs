using System;

namespace Duplicates.Data.Entities
{
    public class Statistic
    {
        public int Cmd { get; set; }
        public int Hdr1 { get; set; }
        public int Hdr2 { get; set; }
        public int Hdr3 { get; set; }
        public int Hdr4 { get; set; }
        public int Flags { get; set; }
        public int Steps { get; set; }
        public int MaxHr { get; set; }
        public int MinHr { get; set; }
        public string SensorId { get; set; }
        public int RecId { get; set; }
        public DateTime AddDate { get; set; }
        public int Distance { get; set; }
        public int EnergyIn { get; set; }
        public int Precision { get; set; }
        public int Reserved1 { get; set; }
        public int Reserved2 { get; set; }
        public int Reserved3 { get; set; }
        public long Timestamp { get; set; }
        public int EnergyOut { get; set; }
        public int HeartRate { get; set; }
        public int UtcOffset { get; set; }
        public int FirstRecId { get; set; }
        public int StressLevel { get; set; }
        public int BatteryLevel { get; set; }
        public int ActivityWaterLoss { get; set; }
        public decimal MetabolicWaterLoss { get; set; }
    }
}
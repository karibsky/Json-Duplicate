using System;
using System.ComponentModel;

namespace Duplicates.Data.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public long OriginalFileSize { get; set; }
        public long CompressedFileSize { get; set; }
        public DateTime Date { get; set; }
        public EventType EventType { get; set; }
    }

    public enum EventType
    {
        [Description("Удаление дубликатов")]
        DeleteDuplicates
    }
}
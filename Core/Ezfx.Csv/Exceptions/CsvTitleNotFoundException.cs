using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class CsvNameNotFoundException : CsvMappingException
    {
        public CsvNameNotFoundException() : base() { }
        public CsvNameNotFoundException(string message) : base(message) { }
        public CsvNameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvNameNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class CsvMappingException : CsvException
    {
        public CsvMappingException() : base() { }
        public CsvMappingException(string message) : base(message) { }
        public CsvMappingException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvMappingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

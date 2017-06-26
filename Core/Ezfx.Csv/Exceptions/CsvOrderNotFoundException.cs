using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class CsvOrderNotFoundException : CsvMappingException
    {
        public CsvOrderNotFoundException() : base() { }
        public CsvOrderNotFoundException(string message) : base(message) { }
        public CsvOrderNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvOrderNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

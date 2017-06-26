using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class CsvEncodingNotFoundException : CsvException
    {
        public CsvEncodingNotFoundException() : base() { }
        public CsvEncodingNotFoundException(string message) : base(message) { }
        public CsvEncodingNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvEncodingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

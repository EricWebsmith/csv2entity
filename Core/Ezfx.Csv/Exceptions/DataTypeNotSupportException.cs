using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class DataTypeNotSupportException : CsvException
    {
        public DataTypeNotSupportException() : base() { }
        public DataTypeNotSupportException(string message) : base(message) { }
        public DataTypeNotSupportException(string message, Exception innerException) : base(message, innerException) { }
        protected DataTypeNotSupportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class ParseException : CsvException
    {
        public ParseException() : base() { }
        public ParseException(string message) : base(message) { }
        public ParseException(string message, Exception innerException) : base(message, innerException) { }
        public ParseException(string type, string value) : base("value '" + value + "' cannot parse to " + type) { }
        public ParseException(Type type, string value) : base("value '" + value + "' cannot parse to " + type.Name) { }
        protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}

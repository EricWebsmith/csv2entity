using System;
using System.Runtime.Serialization;

namespace Ezfx.Csv
{
    [Serializable]
    public class CsvException : Exception
    {
        public CsvException() : base() { }
        public CsvException(string message) : base(message) { }
        public CsvException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CsvFormatException : Exception
    {
        public CsvFormatException() : base("We use RFC 4180 standard, and your file seams not abey this standard. for more information: https://tools.ietf.org/html/rfc4180.") { }
        public CsvFormatException(string message) : base(message) { }
        public CsvFormatException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvFormatException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CsvEncodingNotFoundException : CsvException
    {
        public CsvEncodingNotFoundException() : base() { }
        public CsvEncodingNotFoundException(string message) : base(message) { }
        public CsvEncodingNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvEncodingNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CsvMappingException : CsvException
    {
        public CsvMappingException() : base() { }
        public CsvMappingException(string message) : base(message) { }
        public CsvMappingException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvMappingException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CsvOrderNotFoundException : CsvMappingException
    {
        public CsvOrderNotFoundException() : base() { }
        public CsvOrderNotFoundException(string message) : base(message) { }
        public CsvOrderNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvOrderNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class CsvNameNotFoundException : CsvMappingException
    {
        public CsvNameNotFoundException() : base() { }
        public CsvNameNotFoundException(string message) : base(message) { }
        public CsvNameNotFoundException(string message, Exception innerException) : base(message, innerException) { }
        protected CsvNameNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class DataTypeNotSupportException : CsvException
    {
        public DataTypeNotSupportException() : base() { }
        public DataTypeNotSupportException(string message) : base(message) { }
        public DataTypeNotSupportException(string message, Exception innerException) : base(message, innerException) { }
        protected DataTypeNotSupportException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

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

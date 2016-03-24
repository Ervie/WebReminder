using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebReminder.Exceptions
{
    public class DBConnectionException : Exception
    {

        public DBConnectionException() : base()
        {
        }

        public DBConnectionException(string message): base(message)
        {
        }

        public DBConnectionException(String message, Exception innerException) : base(message, innerException)
        {
        }

        protected DBConnectionException(SerializationInfo info, StreamingContext context): base(info, context) 
        {
        }
    
    }
}
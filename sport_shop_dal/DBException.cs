using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_dal
{
    internal class DBException : Exception
    {
        public DBException()
        {
        }

        public DBException(string? message) : base(message)
        {
        }

        public DBException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected DBException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

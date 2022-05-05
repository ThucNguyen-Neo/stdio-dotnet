using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace STDIO_dotNet
{
    [Serializable]
    internal class StudentException : Exception
    {
        public StudentException(string message)
            : base(message)
        {
        }
        public StudentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        public StudentException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

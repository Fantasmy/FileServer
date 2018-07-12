using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Utils.CustomException
{
    [Serializable]
    public class VuelingException : Exception
    {
        public VuelingException()
           : base()
        {

        }
        public VuelingException(string message) : base(message)
        {

        }

        public VuelingException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public VuelingException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }

}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Reinventing The Wheel (only for the purposes of demonstrating the features of the language)
/// </summary>
namespace MatrixDemo.RTW
{
    /// <summary>
    /// The BadDimensionException is thrown when a matrix operation is incompatible with the dimensions of its operands.
    /// </summary>
    public class BadDimensionException : Exception
    {
        public BadDimensionException() : base()
        {

        }

        public BadDimensionException(String message) : base(message)
        {

        }

        public BadDimensionException(SerializationInfo sinfo, StreamingContext scontext) : base(sinfo,scontext)
        {

        }

        public BadDimensionException(String message, Exception ex) : base(message,ex)
        {

        }

    }
}

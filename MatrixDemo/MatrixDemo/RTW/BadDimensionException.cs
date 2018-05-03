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

        /// <summary>
        /// Creates a new BadDimensionException.
        /// </summary>
        public BadDimensionException() : base()
        {

        }

        /// <summary>
        /// Creates a new BadDimensionException with a specific message.
        /// </summary>
        /// <param name="message">the message to accompany this exception.</param>
        public BadDimensionException(String message) : base(message)
        {

        }

        /// <summary>
        /// Creates a new BadDimensionException with serialized info.
        /// </summary>
        /// <param name="sinfo">The serialization object containing serialization info.</param>
        /// <param name="scontext">The object containing information about the serialization context.</param>
        public BadDimensionException(SerializationInfo sinfo, StreamingContext scontext) : base(sinfo,scontext)
        {

        }

        /// <summary>
        /// Creates a BadDimensionException with a specific error message and cause exception.
        /// </summary>
        /// <param name="message">The message to accompany this BadDimensionException.</param>
        /// <param name="ex">The exception that caused this exception to occur.</param>
        public BadDimensionException(String message, Exception ex) : base(message,ex)
        {

        }

    }
}

using System;

namespace Thalus.Contracts
{
    public interface IError
    {
        /// <summary>
        ///  Gets the return code according to <see cref="StatusCode"/>
        /// </summary>
        int Code { get; }

        /// <summary>
        /// Indicates that the result is an exception
        /// </summary>
        bool IsException { get; }
        
        /// <summary>
        /// Gets the type of exception depending to the <see cref="IsException"/> flag.
        /// </summary>
        Type ExceptionType { get; }

        /// <summary>
        ///  Gets the underlying data value as typed exception
        /// </summary>
        /// <typeparam name="TType">Pass teh type to e data shall be converted to</typeparam>
        /// <returns>Returns the Exceptiona ccording to type</returns>
        TType GetException<TType>() where TType : Exception;

       
    }

    public interface IWait
    {
        IConfiguration Wait();
    }
}



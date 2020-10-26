using System;

namespace Thalus.Contracts
{
    /// <summary>
    /// Indicates that the object delivers typed data 
    /// </summary>
    public interface IProvideData
    {
        /// <summary>
        ///  Retruns a typed data object
        /// </summary>
        /// <typeparam name="TType">Pass the type to convert the underlying object to</typeparam>
        /// <returns>Returns object of type TType</returns>
        /// <exception cref="InvalidCastException">Thrown when data could not be assigned to return type</exception>
        TType GetData<TType>() where TType : class;
    }
}



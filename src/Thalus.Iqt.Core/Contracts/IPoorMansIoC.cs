using System;
using Thalus.Contracts;

namespace Thalus.Iqt.Core.Contracts
{
    /// <summary>
    /// Publishes the public members of <see cref="IPoorMansIoC"/> such like
    /// <see cref="Get{TType}"/> and <see cref="Register{TType}(Func{object})"/>
    /// </summary>
    public interface IPoorMansIoC
    {
        /// <summary>
        /// Gets an instance of the specified type from IoC Container
        /// </summary>
        /// <typeparam name="TType">Pass the type to create an instance for</typeparam>
        /// <returns>Returns the result of creation as <see cref="IResult{TType}"/></returns>
        IResult<TType> Get<TType>();

        /// <summary>
        /// Registers a creation policy for a specific type
        /// </summary>
        /// <typeparam name="TType">Pass the type tp create a policy for</typeparam>
        /// <param name="a">Pass the create function</param>
        void Register<TType>(Func<object> a);
    }
}
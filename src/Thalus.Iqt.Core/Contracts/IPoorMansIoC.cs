using System;
using Thalus.Contracts;

namespace Thalus.Iqt.Core
{
    public interface IPoorMansIoC
    {
        IResult<TType> Get<TType>();
        void Register<TType>(Func<object> a);
    }
}
using System;
using System.Collections.Generic;
using Thalus.Contracts;

namespace Thalus.Iqt.Core
{
    public abstract class PoorMansIoC : IPoorMansIoC
    {
        bool _favorExceptionsOverResult;
        Dictionary<Type, Func<IPoorMansIoC, object>> _creators;

        public PoorMansIoC(bool favorExceptionsOverResult)
        {
            _favorExceptionsOverResult = favorExceptionsOverResult;
            _creators = Initialize();
        }

        protected abstract Dictionary<Type, Func<IPoorMansIoC, object>> Initialize();

        public void Register<TType>(Func<IPoorMansIoC, object> a)
        {
            _creators[typeof(TType)] = a;
        }

        public IResult<TType> Get<TType>()
        {
            var type = typeof(TType);

            try
            {
                Func<IPoorMansIoC, object> o;
                if (!_creators.TryGetValue(type, out o))
                {
                    var ex = new IqtTypeNotFoundException(type, $"Passed type={type} was not listed. An instance could not be created");
                    if (_favorExceptionsOverResult)
                    {
                        throw ex;
                    }

                    return Result.Exception<TType>(ex, ex.Message);
                }

                return Result.Ok((TType)o.Invoke(this));
            }
            catch (Exception ex)
            {
                var nEx = new IqtInstanceCreateException(type, $"Passed type={type} was listed but an instance could not not be created", ex);

                if (_favorExceptionsOverResult)
                {
                    throw nEx;
                }

                return Result.Exception<TType>(nEx, nEx.Message);
            }
        }
    }

    public class IqtInstanceCreateException : Exception
    {
        public IqtInstanceCreateException(Type tp) : base()
        {
            Type = tp;
        }

        public IqtInstanceCreateException(Type tp, Exception ex) : base(ex.Message, ex)
        {
            Type = tp;
        }

        public IqtInstanceCreateException(Type tp, string message, Exception ex) : base(message, ex)
        {
            Type = tp;
        }

        public IqtInstanceCreateException(Type tp, string message) : base(message)
        {
            Type = tp;
        }

        public Type Type { get; }
    }

    public class IqtTypeNotFoundException : Exception
    {
        public IqtTypeNotFoundException(Type tp) : base()
        {
            Type = tp;
        }

        public IqtTypeNotFoundException(Type tp, Exception ex) : base(ex.Message, ex)
        {
            Type = tp;
        }

        public IqtTypeNotFoundException(Type tp, string message, Exception ex) : base(message, ex)
        {
            Type = tp;
        }

        public IqtTypeNotFoundException(Type tp, string message) : base(message)
        {
            Type = tp;
        }

        public Type Type { get; }
    }
}

using System;

namespace Thalus.Contracts
{
    public class ErrorDTO : IError, IProvideText, IProvideData, IProvideCodedResult
    {
        public TextDTO Text { get; set; }

        IText IProvideText.GetText() { return new TextDTO(Text); }

        public int Code { get; set; }

        public bool Success => StatusCode.IsError(Code);

        public bool IsException => typeof(Exception).CanAssign(Data);
        public Type ExceptionType { get { if (IsException) { return Data.GetType(); } return null; } }

        public object Data { get; set; }

        public Exception Exception => (Exception)Data;

        public TType GetData<TType>() where TType : class
        {
            if (Data == null)
            {
                return default(TType);
            }

            var tp = typeof(TType);
            Type dataType = Data.GetType();

            var t = Data as TType;

            if (t != null)
            {
                return t;
            }

            throw new InvalidCastException($"Unable to cast DataType={dataType} to TType={tp }");
        }

        public TType GetException<TType>() where TType : Exception
        {
            if (!IsException)
            {
                return null;
            }

            if (ExceptionType.CanAssign<TType>())
            {
                return (TType)Data;
            }

            throw new InvalidCastException($"Unable to cast DataType={Data.GetType()} to TType={ExceptionType }");
        }
    }
}



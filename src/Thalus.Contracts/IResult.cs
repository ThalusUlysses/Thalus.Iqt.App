namespace Thalus.Contracts
{
    public interface IResult : IProvideText, IProvideData, IProvideCodedResult
    {
        /// <summary>
        ///  Gets the data object that has been included into the result
        /// </summary>
        object Data { get; }

        /// <summary>
        ///  Gets gets the error information as <see cref="IError"/>
        /// </summary>
        IError GetError();
    }

    public interface IDataProcessor
    {
        IResult Execute(object data);
        bool CanExecute(object data);
    }

    public interface IResult<TType> : IResult
    {
        TType ResultSet { get; }

        void ThrowIfException();

    }

}



namespace Thalus.Contracts
{
    /// <summary>
    /// Provides a Heartbeat to a service
    /// </summary>
    public interface IProvideHeartBeat
    {
        /// <summary>
        /// Triggers heartbeat signal
        /// </summary>
        /// <returns></returns>
        IResult Beat();
    }
}



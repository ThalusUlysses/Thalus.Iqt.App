using System;

namespace Thalus.Contracts
{
    public interface IScheduler
    {
        IResult Schedule(string id, TimeSpan span, Action callback);
        IResult Unschedule(string id);
    }
}
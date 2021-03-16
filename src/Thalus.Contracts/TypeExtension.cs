using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Thalus.Contracts
{

    public static class TypeExtension
    {
        public static bool CanAssign(this Type tp, object dataType)
        {
            return tp == dataType.GetType();
        }
    }

    /// <summary>
    /// Publishes the public memebers of <see cref="IScheduleItem"/> such like 
    /// <see cref="Id"/> or <see cref="LastTickUtc"/>. USed for scheduling am
    /// element to be called within a specific time span
    /// </summary>
    public interface IScheduleItem
    {
        /// <summary>
        /// Gets an identifer which is unique that identifies the item as <see cref="string"/>
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the <see cref="DateTime"/> of the last tick or update cycle as UTC
        /// </summary>
        DateTime LastTickUtc { get; }

        /// <summary>
        /// Gets the <see cref="TimeSpan"/> of a single tick cycle. Defines in which span the <see cref="DoEvent"/>
        /// is supposed to be raised
        /// </summary>
        TimeSpan TickCycle { get; set; }
    }

    class ScheduleItem : IScheduleItem
    {
        Action _callback;
        public ScheduleItem(string itemId, Action callback)
        {
            _callback = callback;

            Id = itemId;
            LastTickUtc = DateTime.UtcNow;
        }

        public string Id { get; }
        public DateTime LastTickUtc { get; private set; }

        public TimeSpan TickCycle { get; set; }

        public event Action DoEvent;

        public void Tick()
        {
            LastTickUtc = DateTime.UtcNow;
            _callback();
        }
    }

    public class Scheduler : IScheduler
    {
        static Scheduler _instance;

        List<ScheduleItem> _items = new List<ScheduleItem>();
        Thread _observerThread;
        CancellationTokenSource _cancelTokenSource;
        TimeSpan _cycleTime;
        DateTime _lastDt = DateTime.UtcNow;

        public static Scheduler Get()
        {
            if (_instance == null)
            {
                _instance = new Scheduler(new TimeSpan(0, 0, 0, 0, 100));
            }

            return _instance;
        }

        public static IResult ScheduleItem(string id, TimeSpan span, Action callback)
        {
            Scheduler sched = Get();

            return sched.Schedule(id, span, callback);
        }

        public static IResult UnscheduleItem(string id)
        {
            return Get().Unschedule(id);
        }

        private Scheduler(TimeSpan minimumCycleTime)
        {
            _cycleTime = minimumCycleTime;
        }

        public IResult Initialize()
        {
            try
            {
                if (!IsThreadRunning())
                {
                    SafeStartThread();
                }

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Exception(ex, $"Failed to Initialize scheduler");
            }
        }
        public IResult Teardown()
        {
            try
            {
                SafeStopThread();
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Exception(ex, $"Failed to teardown scheduler");
            }
        }

        public IResult Schedule(string id, TimeSpan span, Action callback)
        {
            try
            {
                if (!IsThreadRunning())
                {
                    SafeStartThread();
                }

                lock (_items)
                {
                    ScheduleItem item = new ScheduleItem(id, callback)
                    {
                        TickCycle = span
                    };

                    var t = _items.FirstOrDefault(i => i.Id == id);
                    if (t != null)
                    {
                        _items.Remove(t);
                    }

                    _items.Add(item);
                    return Result.Ok(data: item);
                }
            }
            catch (Exception ex)
            {
                return Result.Exception(ex, $"Failed to schedule item?{id}");
            }
        }


        public IResult Unschedule(string id)
        {
            try
            {
                lock (_items)
                {
                    var t = _items.FirstOrDefault(i => i.Id == id);
                    _items.Remove(t);
                }

                return Result.Ok();

            }
            catch (Exception ex)
            {
                return Result.Exception(ex, $"Failed to unschedule item?{id}");
            }
        }
        bool IsThreadRunning()
        {
            return _observerThread != null && _observerThread.IsAlive;
        }

        private void SafeStartThread()
        {
            if (_observerThread != null)
            {
                SafeStopThread();
            }

            _observerThread = new Thread(ObserverRollingThrread);

            if (_cancelTokenSource == null)
            {
                _cancelTokenSource = new CancellationTokenSource();
            }
            else if (_cancelTokenSource.IsCancellationRequested)
            {
                _cancelTokenSource.Dispose();
                _cancelTokenSource = new CancellationTokenSource();
            }

            _observerThread.Start();
        }

        private void SafeStopThread()
        {
            if (_observerThread == null || !_observerThread.IsAlive)
            {
                return;
            }

            _cancelTokenSource?.Cancel();

            if (_observerThread.IsAlive)
            {
                Thread.Sleep(400);
            }

            if (_observerThread.IsAlive)
            {
                try
                {
                    _observerThread.Abort();
                }
                catch
                {
                    // ok to do so
                }
            }

            _cancelTokenSource.Dispose();
            _cancelTokenSource = null;
        }

        private void ObserverRollingThrread()
        {
            while (!_cancelTokenSource.Token.IsCancellationRequested)
            {
                Thread.Sleep(_cycleTime);
                DateTime dt = DateTime.UtcNow;
                lock (_items)
                {
                    foreach (var item in _items.ToArray())
                    {
                        if (dt - item.LastTickUtc > item.TickCycle)
                        {
                            item.Tick();
                        }
                    }
                }
            }
        }
    }
}



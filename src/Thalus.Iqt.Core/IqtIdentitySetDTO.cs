namespace Thalus.Iqt.Core
{
    //public abstract class WorkerThread
    //{
    //    object _lock = new object();
    //    bool _stopped;
    //    bool _stopping;

    //    Thread _fred;

    //    public void Stop()
    //    {
    //        lock (_lock)
    //        {
    //            _stopping = true;
    //        }
    //    }

    //    protected abstract void OnStart();
    //    protected abstract void OnStop();        
    //    protected abstract void OnRun();

    //    public void Start()
    //    {
    //        lock (_lock)
    //        {
    //            _stopping = false;
    //            _stopped = false;
    //            OnStart();
    //            if (_fred == null)
    //            {
    //                _fred = new Thread(new ThreadStart(RollingThread));
    //                _fred.Start();
    //            }
    //        }
    //    }

    //    private void SetStopped()
    //    {
    //        lock (_lock)
    //        {
    //            OnStop();
    //            _stopped = true;
    //            _stopping = false;
    //        }
    //    }

    //    public bool Stopping()
    //    {
    //        lock (_lock)
    //        {
    //            return _stopping;
    //        }
    //    }

    //    public bool Stopped()
    //    {
    //        lock (_lock)
    //        {
    //            return _stopped;
    //        }
    //    }


    //    private void RollingThread()
    //    {
    //        try
    //        {
    //            while (!Stopping())
    //            {
    //                OnRun();
    //            }
    //        }
    //        catch (Exception)
    //        {

    //        }
    //        finally 
    //        {
    //            SetStopped();
    //        }
    //    }
    //}
    public class IqtIdentitySetDTO
    {
        public IqtIdentityDTO[] Identities { get; set; }

        public IqtExcludesDTO Excludes { get; set; }
    }
}

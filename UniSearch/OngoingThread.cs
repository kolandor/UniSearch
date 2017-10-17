using System;
using System.Threading;

namespace UniSearch
{
    sealed class OngoingThread
    {
        private Thread _thread;

        private readonly AutoResetEvent _threadStartCotrol;

        private readonly AutoResetEvent _userTreadJoinStartCotrol;

        private readonly ThreadStart _userMethod;

        private readonly ParameterizedThreadStart _parameterizedUserMethod;

        private Exception _userThreadException;

        private object _userData;

        public OngoingThread(ThreadStart userMethod) : this()
        {
            _userMethod = userMethod;
        }

        public OngoingThread(ParameterizedThreadStart parameterizedUserMethod) : this()
        {
            _parameterizedUserMethod = parameterizedUserMethod;
        }

        private OngoingThread()
        {
            _threadStartCotrol = new AutoResetEvent(false);
            _userTreadJoinStartCotrol = new AutoResetEvent(false);
            ThreadException = null;
        }

        ~OngoingThread()
        {
            Stop();
        }

        public void Start(object userData = null)
        {
            //create
            if (_thread == null)
            {
                _thread = new Thread(OngoingThreadMethod) { IsBackground = true, Name = Guid.NewGuid().ToString() };
                _thread.Start();
            }

            //join wait for Thread
            _userTreadJoinStartCotrol.WaitOne();
            //set new thread data
            _userData = userData;
            //start Thread
            _threadStartCotrol.Set();
        }

        public void Stop()
        {
            if (_thread != null)
            {
                _thread.Abort();
                _thread = null;
                _userTreadJoinStartCotrol.Reset();
                _threadStartCotrol.Reset();
            }
        }

        public void Join()
        {
            if (_thread != null)
            {
                _userTreadJoinStartCotrol.WaitOne();

                //set AutoResetEvent to Signal sate
                _userTreadJoinStartCotrol.Set();
            }
        }

        public bool IsWork
        {
            get
            {
                bool isWork = _userTreadJoinStartCotrol.WaitOne(0);
                if (isWork)
                {
                    //set AutoResetEvent to Signal sate
                    _userTreadJoinStartCotrol.Set();
                }
                return !isWork;
            }
        }

        public Exception ThreadException
        {
            get
            {
                Exception toReturn = _userThreadException;
                _userThreadException = null;
                return toReturn;
            }
            private set { _userThreadException = value; }
        }

        private void OngoingThreadMethod()
        {
            try
            {
                while (true)
                {
                    try
                    {
                        //user can set new data (Method Join() and Start() not block Thread)
                        _userTreadJoinStartCotrol.Set();

                        //wait for incoming user command to Start
                        _threadStartCotrol.WaitOne();
                        
                        if (_userMethod != null)
                        {
                            _userMethod.Invoke();
                        }
                        else
                        {
                            _parameterizedUserMethod.Invoke(_userData);
                        }
                    }
                    catch (Exception exception)
                    {
                        ThreadException = exception;
                    }
                }
            }
            catch
            {
                //ignore
            }
            finally
            {
                //prevention of nullification of a newly created Thread
                if (_thread != null && _thread.Name == Thread.CurrentThread.Name)
                {
                    _thread = null;
                    _userTreadJoinStartCotrol.Reset();
                    _threadStartCotrol.Reset();
                }
            }
        }
    }
}

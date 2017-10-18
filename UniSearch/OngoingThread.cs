using System;
using System.Threading;

namespace UniSearch
{
    /// <summary>
    /// Resumed working thread
    /// </summary>
    sealed class OngoingThread
    {
        private Thread _thread;
        
        private readonly AutoResetEvent _threadStartCotrol;
        
        private readonly AutoResetEvent _userTreadJoinStartCotrol;
        
        private readonly ThreadStart _userMethod;
        
        private readonly ParameterizedThreadStart _parameterizedUserMethod;
        
        private Exception _userThreadException;
        
        private object _userData;

        /// <summary>
        /// Initializes a new instance of the <see cref="OngoingThread"/> class.
        /// </summary>
        /// <param name="userMethod">The user method.</param>
        public OngoingThread(ThreadStart userMethod) : this()
        {
            _userMethod = userMethod;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OngoingThread"/> class.
        /// </summary>
        /// <param name="parameterizedUserMethod">The parameterized user method.</param>
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

        /// <summary>
        /// Starts thread.
        /// </summary>
        /// <param name="userData">The user data.</param>
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

        /// <summary>
        /// Stops thread.
        /// </summary>
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

        /// <summary>
        /// Joins this thread.
        /// </summary>
        public void Join()
        {
            if (_thread != null)
            {
                _userTreadJoinStartCotrol.WaitOne();

                //set AutoResetEvent to Signal sate
                _userTreadJoinStartCotrol.Set();
            }
        }

        /// <summary>
        /// Get state of thread.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is work; otherwise, <c>false</c>.
        /// </value>
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

        /// <summary>
        /// Gets the thread exception.
        /// </summary>
        /// <value>
        /// The thread exception.
        /// </value>
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

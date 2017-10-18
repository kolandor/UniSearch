using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace UniSearch
{
    public class UniSearchCore
    {
        private readonly FormUniSearch _uniSearch;

        private readonly ListView _searchInfoListView;

        private readonly ProgressBar _prorgressBar;

        private readonly object _criticalSection = true;

        private Thread _mainThread;

        private int _targetDeep;

        private bool _isStop;

        private ManualResetEvent _pauseResetEvent;

        public UniSearchCore(FormUniSearch uniSearch, ListView listView, ProgressBar prorgressBar)
        {
            _isStop = true;
            _uniSearch = uniSearch;
            _prorgressBar = prorgressBar;
            _searchInfoListView = listView;
            _pauseResetEvent = new ManualResetEvent(true);
        }

        public void Start(string urlRoot, int targetDeep, int threadCount, string searchString)
        {
            _targetDeep = targetDeep;

            Tuple<string, int, string> tuple =
                new Tuple<string, int, string>
                (urlRoot, threadCount, searchString);

            _mainThread = new Thread(Process) { IsBackground = true };
            _mainThread.Start(tuple);
        }

        public void Stop()
        {
            if (_mainThread != null)
            {
                _mainThread.Abort();

                _mainThread = null;
            }
        }

        public void Pause()
        {
            _pauseResetEvent.Reset();
        }

        public void Resume()
        {
            _pauseResetEvent.Set();
        }

        public event Action FinishScan;

        void Process(object objTupleParams)
        {
            List<OngoingThread> poolThreads = null;

            _isStop = false;

            try
            {
                Tuple<string, int, string> paramsTuple = objTupleParams as Tuple<string, int, string>;

                if (paramsTuple == null)
                {
                    throw new Exception("Main Thread: Wrong input params");
                }

                string urlRoot = paramsTuple.Item1;
                int threadCount = paramsTuple.Item2;
                string searchString = paramsTuple.Item3;

                poolThreads = new List<OngoingThread>();

                for (int i = 0; i < threadCount; i++)
                {
                    poolThreads.Add(new OngoingThread(SearchMethod));
                }

                List<string> scanned = new List<string>();
                List<string> scan = new List<string> { urlRoot };

                while (scan.Count > 0 && scanned.Count <= _targetDeep)
                {
                    _pauseResetEvent.WaitOne();
                    scan = ScanLevel(poolThreads, scan, scanned, searchString);
                }

                lock (_criticalSection)
                {
                    _uniSearch.Invoke((MethodInvoker)delegate
                   {
                       _prorgressBar.Value = _prorgressBar.Maximum;
                   });
                }
            }
            catch (ThreadAbortException)
            {
                //ignore
            }
            catch (Exception exception)
            {
                //if (!(Exception is ThreadAbortException))
                //{
                MessageBox.Show(exception.Message);
                //}
            }
            finally
            {
                _isStop = true;

                if (poolThreads != null)
                {
                    foreach (OngoingThread thread in poolThreads)
                    {
                        thread.Stop();
                    }
                }
                _mainThread = null;
                OnFinishScan();
            }
        }

        List<string> ScanLevel(List<OngoingThread> poolThreads, List<string> scan, List<string> scanned, string searchString)
        {
            List<string> nextScan = new List<string>();

            for (int i = 0; i < scan.Count; i++)
            {
                Tuple<string, List<string>, List<string>, string> tupleScanData =
                    new Tuple<string, List<string>, List<string>, string>(scan[i], scanned, nextScan, searchString);

                _pauseResetEvent.WaitOne();

                poolThreads[i % poolThreads.Count].Start(tupleScanData);
            }

            //wait for scan level
            foreach (OngoingThread thread in poolThreads)
            {
                thread.Join();
            }

            if (nextScan.Count + scanned.Count > _targetDeep)
            {
                nextScan.RemoveRange(0, nextScan.Count + scanned.Count - _targetDeep);
            }

            return nextScan;
        }

        void SearchMethod(object objTupleParams)
        {
            _pauseResetEvent.WaitOne();

            ListViewItem item = new ListViewItem();

            try
            {
                Tuple<string, List<string>, List<string>, string> paramsTuple =
                    objTupleParams as Tuple<string, List<string>, List<string>, string>;

                if (paramsTuple == null)
                {
                    throw new Exception("Wrong thread search params.");
                }

                string currentUrl = paramsTuple.Item1;
                List<string> scanned = paramsTuple.Item2;
                List<string> nextScan = paramsTuple.Item3;
                string searchString = paramsTuple.Item4;

                lock (_criticalSection)
                {
                    _uniSearch.Invoke((MethodInvoker) delegate
                    {
                        _searchInfoListView.Items.Add(item);
                    });
                }

                //set of the researched url
                lock (_criticalSection)
                {
                    _uniSearch.Invoke((MethodInvoker) delegate
                    {
                        item.Text += currentUrl;
                    });
                }

                lock (_criticalSection)
                {
                    scanned.Add(currentUrl);
                }

                string html = GetHtml(currentUrl);

                html = html.ToLower();

                int coutnConcurrences = Regex.Matches(html, searchString.ToLower()).Count;

                lock (_criticalSection)
                {
                    _uniSearch.Invoke((MethodInvoker) delegate
                    {
                        item.Text += @" Concurrences: " + coutnConcurrences;
                    });
                }

                Regex regex = new Regex(@"https?://[\w\d\-_]+(\.[\w\d\-_]+)+[\w\d\-\.,@?^=%&amp;:/~\+#]*");

                MatchCollection matches = regex.Matches(html);

                lock (_criticalSection)
                {
                    nextScan.AddRange(from Match match in matches
                        where !scanned.Contains(match.Value)
                        select match.Value);
                }
            }
            catch (Exception exception)
            {
                lock (_criticalSection)
                {
                    _uniSearch.Invoke((MethodInvoker) delegate
                    {
                        item.Text += @" Search error: " + exception.Message;
                    });
                }
            }
            finally
            {
                ProgressUp();
            }
        }

        private string GetHtml(string currentUrl)
        {
            _pauseResetEvent.WaitOne();

            string html;

            HttpWebRequest request = WebRequest.CreateHttp(currentUrl);

            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                if (stream == null)
                {
                    throw new Exception("can't get web page.");
                }
                using (StreamReader reader = new StreamReader(stream))
                {
                    html = reader.ReadToEnd();
                    if (html.Length == 0)
                    {
                        throw new Exception("can't get web page html.");
                    }
                }
                stream.Close();
            }

            return html;
        }

        private void ProgressUp()
        {
            if (!_isStop)
            {
                lock (_criticalSection)
                {
                    _uniSearch.Invoke((MethodInvoker) delegate
                    {
                        _prorgressBar.Value = _prorgressBar.Value + 1 > _prorgressBar.Maximum
                            ? _prorgressBar.Maximum
                            : _prorgressBar.Value + 1;
                    });
                }
            }
        }

        protected virtual void OnFinishScan()
        {
            FinishScan?.Invoke();
        }
    }
}

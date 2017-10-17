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
        public delegate void ProrgressBarUp(int newValue);

        private readonly ListView _searchInfoListView;
        
        private readonly ProrgressBarUp _prorgressBarUp;

        private readonly object _criticalSection = true;

        private Thread _mainThread;

        private int _targetDeep;

        public UniSearchCore(ListView listView, ProrgressBarUp prorgressBarUp)
        {
            _prorgressBarUp = prorgressBarUp;
            _searchInfoListView = listView;
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

        }

        void Process(object objTupleParams)
        {
            try
            {
                Tuple<string,  int, string> paramsTuple = objTupleParams as Tuple<string, int, string>;

                if (paramsTuple == null)
                {
                    throw new Exception("Main Thread: Wrong input params");
                }

                string urlRoot = paramsTuple.Item1;
                int threadCount = paramsTuple.Item2;
                string searchString = paramsTuple.Item3;

                List<OngoingThread> poolThreads = new List<OngoingThread>();

                for (int i = 0; i < threadCount; i++)
                {
                    poolThreads.Add(new OngoingThread(SearchMethod));
                }

                List<string> scanned = new List<string>();
                List<string> scan = new List<string> { urlRoot };
                
                while (scan.Count > 0 && scanned.Count <= _targetDeep)
                {
                    List<string> nextScan = new List<string>();

                    for (int i = 0; i < scan.Count; i++)
                    {
                        Tuple<string, List<string>, List<string>, string> tupleScanData =
                            new Tuple<string, List<string>, List<string>, string>(scan[i], scanned, nextScan, searchString);

                        poolThreads[i % poolThreads.Count].Start(tupleScanData);
                    }

                    //wait for scan level
                    foreach (OngoingThread thread in poolThreads)
                    {
                        thread.Join();
                    }

                    _prorgressBarUp.Invoke(scanned.Count);

                    if (nextScan.Count + scanned.Count > _targetDeep)
                    {
                        nextScan.RemoveRange(0, nextScan.Count + scanned.Count - _targetDeep);
                    }

                    scan = nextScan;
                }

                foreach (OngoingThread thread in poolThreads)
                {
                    thread.Stop();
                }

                _prorgressBarUp.Invoke(-1);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void SearchMethod(object objTupleParams)
        {
            ListViewItem item = new ListViewItem();
            
            try
            {
                Tuple<string, List<string>, List<string>, string> paramsTuple = 
                    objTupleParams as Tuple<string, List<string>, List<string>, string>;

                if (paramsTuple == null)
                {
                    throw new Exception("Wrong thread search params.");
                }

                //if (paramsTuple.Item2.Count >= _targetDeep)
                //{
                //    return;
                //}

                lock (_criticalSection)
                {
                    _searchInfoListView.Items.Add(item);
                }

                string currentUrl = paramsTuple.Item1;
                List<string> scanned = paramsTuple.Item2;
                List<string> nextScan = paramsTuple.Item3;
                string searchString = paramsTuple.Item4;

                item.Text += currentUrl;

                lock (_criticalSection)
                {
                    scanned.Add(currentUrl);
                }

                string html = string.Empty;

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

                html = html.ToLower();

                item.Text += @" Concurrences: " + Regex.Matches(html, searchString.ToLower()).Count;

                //Working stable regular expressions
                //Public pattern
                //Regex regex = new Regex(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
                //My complicated pattern
                //Regex regex = new Regex(@"https?://[\w\d\-_]+(\.[\w\d\-_]+)+[\w\d\-\.,@?^=%&amp;:/~\+#]*");
                //My simple pattern
                //Regex regex = new Regex(@"https?://[\w\d-\._~:/?#\[\]@!$&'()*+,;=`]+");

                Regex regex = new Regex(@"https?://[\w\d\-_]+(\.[\w\d\-_]+)+[\w\d\-\.,@?^=%&amp;:/~\+#]*");

                MatchCollection matches = regex.Matches(html);

                lock (_criticalSection)
                {
                    nextScan.AddRange(from Match match in matches where !scanned.Contains(match.Value) select match.Value);
                }
            }
            catch (Exception exception)
            {
                item.Text += @" Search error: " + exception.Message;
            }
        }
    }
}

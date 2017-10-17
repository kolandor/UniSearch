using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace UniSearch
{
    public class UniSearchCore
    {
        //Working stable regular expressions
        //Public pattern
        //Regex regex = new Regex(@"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");
        //My complicated pattern
        //Regex regex = new Regex(@"https?://[\w\d\-_]+(\.[\w\d\-_]+)+[\w\d\-\.,@?^=%&amp;:/~\+#]*");
        //My simple pattern
        //Regex regex = new Regex(@"https?://[\w\d-\._~:/?#\[\]@!$&'()*+,;=`]+");



        private ListView _searchInfoListView;

        private object _criticalSection = true;

        private Thread _mainThread = null;

        public UniSearchCore(ListView listView)
        {
            _searchInfoListView = listView;
        }

        public void Start(string urlRoot, int searchDeep, int threadCount)
        {
            Tuple<string, int, int> tuple = new Tuple<string, int, int>(urlRoot, searchDeep, threadCount);
            _mainThread = new Thread(Process) { IsBackground = true };
            _mainThread.Start(tuple);
        }

        public void Stop()
        {

        }

        public void Pause()
        {

        }

        void Process(object objTupleParams)
        {
            try
            {
                Tuple<string, int, int> paramsTuple = objTupleParams as Tuple<string, int, int>;

                if (paramsTuple == null)
                {
                    throw new Exception("Main Thread: Wrong input params");
                }

                string urlRoot = paramsTuple.Item1;
                int searchDeep = paramsTuple.Item2;
                int threadCount = paramsTuple.Item3;

                List<OngoingThread> poolThreads = new List<OngoingThread>();

                for (int i = 0; i < threadCount; i++)
                {
                    poolThreads.Add(new OngoingThread(SearchMethod));
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        void SearchMethod(object objTupleParams)
        {
            Tuple<string, List<string>, List<string>> paramsTuple = objTupleParams as Tuple<string, List<string>, List<string>>;
        }
    }
}

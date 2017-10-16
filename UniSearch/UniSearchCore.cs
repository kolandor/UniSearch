using System.Threading;
using System.Windows.Forms;

namespace UniSearch
{
    public class UniSearchCore
    {
        private ListView _searchInfoListView;

        private Thread _mainThread = null;

        public UniSearchCore(ListView listView)
        {
            _searchInfoListView = listView;
        }

        public void Start(string urlRoot, int searchDeep, int threadCount)
        {
            
        }

        public void Stop()
        {
            
        }

        public void Pause()
        {
            
        }
    }
}

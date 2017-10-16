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

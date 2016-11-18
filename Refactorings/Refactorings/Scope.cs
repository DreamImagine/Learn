using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class ActivityContext
    {
        private static ActivityContext current;
        public string ActivityName { get; private set; }
        public DateTime StartTime { get; private set; }

        public IDictionary<string, object> Propertes { get; set; }

        internal ActivityContext(string activeityName)
        {
            this.ActivityName = activeityName;
            this.StartTime = DateTime.Now;
            this.Propertes = new Dictionary<string, object>();
        }
        public static ActivityContext Current
        {
            get { return current; }
            internal set { current = value; }
        }

        public void Dispose()
        {
            foreach (var property in this.Propertes.Values)
            {
                IDisposable disposable = property as IDisposable;
                if (null != disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}

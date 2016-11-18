using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.委托
{
    public class 委托_Test
    {

        public IEnumerable<string> Wheres(Func<string, bool> where)
        {

            return new List<string>();
        }

        public void Test()
        {
            Wheres(w => w.Length == 2);

        }

    }
}

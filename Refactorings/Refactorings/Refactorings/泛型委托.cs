using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 泛型委托
    {
        public delegate void Del<T>(T item);
        public static void Notify(int i) { }

        Del<int> m1 = new Del<int>(Notify);


    }
}

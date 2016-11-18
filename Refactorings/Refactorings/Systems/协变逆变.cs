using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.Systems
{
    public class 协变逆变
    {

        //协变：指能够使用比原始指定的派生类型的派生程度更小的类型


        //逆变：指能够使用比原始指定的派生类型的派生程度更大的类型。
        public void Test()
        {
            IEnumerable<Derived> d = new List<Derived>() { new Derived { 逆变 = "逆变1", 协变 = "斜边1" }, new Derived { 逆变 = "逆变2", 协变 = "斜边2" } };
            IEnumerable<Base> b = d;

            foreach (var item in b)
            {
                Console.WriteLine(item.逆变);
            }
        }


    }

    public class Base
    {
        public string  逆变 { get; set; }
    }

    public class Derived : Base
    {
        public string 协变 { get; set; }
    }
}

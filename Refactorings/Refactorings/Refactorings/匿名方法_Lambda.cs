using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 匿名方法_Lambda
    {

        //在C#3.0 以后及更高的版本中，lambda表达式取代了匿名方法
        //来作为编写内联代码的首选方式

        //要将代码块传递为委托参数，创建匿名方法则是唯一的方法。

        delegate void Del();

        //Del d = delegate(int k) { };


        //通过使用匿名的方法，由于您不必创建单独的方法，因此减少了实例化委托所需的
        //编码系统开销
        //例如，如果创建方法所需的系统开销是不必要的，则制定代码块（而不是委托）可能非常有用
        //启动新线程即是一个很好的示例
        //无需为委托创建更多方法，线程类即可创建一个线程并且包含该线程执行的代码。

        public void StartThread()
        {
            System.Threading.Thread t1 = new System.Threading.Thread(delegate()
            {
                Console.Write("hello");
                Console.WriteLine("World!");

            });
            t1.Start();
        }


        public void Test()
        {
            int n = 0;
            Del d = delegate() { Console.WriteLine("Copyd#:{0}", ++n); };
            Del d2 = () => { Console.WriteLine("Copyd2#:{0}", ++n); };
            d2 += d;
            d();
            Console.WriteLine("\n");
            d2();
              Console.WriteLine("\n");
            Del d3 = d + d2;
            d3();
        
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Refactorings.并行
{
    public class Task_演示
    {

        public void ShowTest()
        {

            Task task = new Task(()=>Console.WriteLine("Hello from taskA."));

            task.Start();
            Console.WriteLine("Hello from thread '{0}'",Thread.CurrentThread.Name);

           task.Wait();
        }
    }
}

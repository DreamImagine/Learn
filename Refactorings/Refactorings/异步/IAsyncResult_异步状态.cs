using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Refactorings.异步
{
    public class IAsyncResult_异步状态
    {
      
    }
    public class AsyncDemo
    {
        public string TestMethod(int callDuraction, out int threadId)
        {
            Console.WriteLine("Test method begins.");
            Thread.Sleep(callDuraction);
            threadId = Thread.CurrentThread.ManagedThreadId;

            return String.Format("My call time was{0}:", callDuraction.ToString());
        }
        public delegate string AsyncMethodCaller(int callDuration, out int threadId);
    }
    public class AsyncMain
    {
        static void Main()
        {
            AsyncDemo ad = new AsyncDemo();
        }

    }
}

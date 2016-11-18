using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Refactorings.委托
{

    /// <summary>
    /// Callback 回掉，Async:异步
    /// </summary>
    public static class 委托_AsyncCallback
    {
        //引用在相应异步操作完成时调用的方法
        //ar
        //  异步操作的结果。 


        static int requestCounter;
        static ArrayList hostData = new ArrayList();
        static StringCollection hostNamees = new StringCollection();
        static void UpdateUserInterface()
        {
            Console.WriteLine("{0}Requests remaining", requestCounter);
        }

        public static void Main()
        {
            AsyncCallback callBack = new AsyncCallback(ProcessDnsInformation);
            string host;
            do
            {
                Console.WriteLine("请输入一个值");
                host = Console.ReadLine();
                if (host.Length > 0)
                {
                    Interlocked.Increment(ref requestCounter);
                    Dns.BeginGetHostEntry(host, callBack, host);

                }

            } while (host.Length > 0);

            while (requestCounter > 0)
            {
                UpdateUserInterface();
            }

            for (int i = 0; i < hostNamees.Count; i++)
            {
                object data = hostData[i];
                string message = data as string;
                if (message != null)
                {
                    Console.WriteLine("Request for {0} returned message:{1}", hostNamees[i], message);
                    continue;
                }
                IPHostEntry h = (IPHostEntry)data;
                string[] aliases = h.Aliases;
                IPAddress[] addressses = h.AddressList;
                if (aliases.Length > 0)
                {
                    Console.WriteLine("Aliases for {0}", hostNamees[i]);
                    for (int j = 0; j < aliases.Length; j++)
                    {
                        Console.WriteLine("{0}", aliases[j]);
                    }
                }

                if (addressses.Length > 0)
                {
                    Console.WriteLine("Addresses for {0}", hostNamees[i]);
                    for (int k = 0; k < addressses.Length; k++)
                    {
                        Console.WriteLine("{0}", addressses[k].ToString());
                    }
                }
            }



        }



        static void ProcessDnsInformation(IAsyncResult result)
        {
            string hostName = (string)result.AsyncState;
            hostNamees.Add(hostName);
            try
            {

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Interlocked.Decrement(ref requestCounter);
            }

        }

    }
}

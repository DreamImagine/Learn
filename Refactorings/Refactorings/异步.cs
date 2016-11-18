using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 异步
    {
    }


    public class PrimeFactorFinder
    {
        public static bool Factorize(
                int number,
                ref int primefactor1,
                ref int primefactor2)
        {
            primefactor1 = 1;
            primefactor2 = number;

            // Factorize using a low-tech approach.
            for (int i = 2; i < number; i++)
            {
                if (0 == (number % i))
                {
                    primefactor1 = i;
                    primefactor2 = number / i;
                    break;
                }
            }
            if (1 == primefactor1)
                return false;
            else
                return true;
        }
    }

    public delegate bool AsyncFactorCaller(int number, ref int primefactor1, ref int primefactor2);


    public class DemonstrateAsyncPattern
    {
        ManualResetEvent waiter;

        public void FactorizedResults(IAsyncResult result)
        {
            int factor1 = 0;
            int factor2 = 0;
            AsyncFactorCaller factorDelegate = ((AsyncResult)result).AsyncDelegate as AsyncFactorCaller;

            int number = (int)result.AsyncState;
            bool answer = factorDelegate.EndInvoke(ref factor1, ref factor2, result);
            Console.WriteLine("On CallBack factors of {0}:{1}{2}{3}", number, factor1, factor2, answer);
            waiter.Set();
        }


        public void FactorizeNumberUsingCallback()
        {
            AsyncFactorCaller factorDelegate = new AsyncFactorCaller(PrimeFactorFinder.Factorize);
            int number = 1000589023;
            int temp = 0;

            waiter = new ManualResetEvent(false);

            AsyncCallback callBack = new AsyncCallback(this.FactorizedResults);

            IAsyncResult result = factorDelegate.BeginInvoke(
                                        number,
                                        ref temp,
                                        ref temp,
                                        callBack,
                                        number);

            waiter.WaitOne();
        }

        public void FactorizeNumberAndWait()
        {
            AsyncFactorCaller factorDelegate = new AsyncFactorCaller(PrimeFactorFinder.Factorize);

            int number = 1000589023;
            int temp = 0;

            //开始调用

            IAsyncResult result = factorDelegate.BeginInvoke(number, ref temp, ref temp, null, null);
            while (!result.IsCompleted)
            {
                result.AsyncWaitHandle.WaitOne(10000, false);
            }
            result.AsyncWaitHandle.Close();

            int factor1 = 0;
            int factor2 = 0;
            bool answer = factorDelegate.EndInvoke(ref factor1, ref factor2, result);

            Console.WriteLine("Squential；Factors of{0}:{1}{2}-{3}",number,factor1,factor2,answer);



        }

        public static void Main()
        {
            DemonstrateAsyncPattern demonstrator = new DemonstrateAsyncPattern();
            demonstrator.FactorizeNumberUsingCallback();
            demonstrator.FactorizeNumberAndWait();
        }

    }

}

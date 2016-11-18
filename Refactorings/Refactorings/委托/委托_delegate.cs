using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{

    /// <summary>
    /// 什么是委托，委托有什么用
    /// delegate 是一种可用于封装命名或匿名方法的引用类型

    /// </summary>

    public class 委托_delegate
    {


        //委托是什么
        //备注
        //委托是事件的基础
        //通过将委托与命名方法或者匿名方法关联，可以实例化委托。
        //怎么定义委托
        public delegate void TestDelegate(string message);




        //在什么情况下使用委托

        public void delegateTest()
        {
            //把具体方法的指针给委托
            MathAction ma = DelegateTest.Double;
            double multByTwo = ma(4.5);
            Console.WriteLine("multByTwo:{0}", multByTwo);


            // Instantiate delegate with anonymous method:
            //实例化委托与匿名方法:

            //实例化委托
            MathAction ma2 = delegate(double input)
            {
                return input * input;
            };

            double square = ma2(5);
            Console.WriteLine("square:{0}", square);


            //匿名委托
            MathAction ma3 = s => s * s * s;
            double cube = ma3(4.375);
            Console.WriteLine("cube:{0}", cube);


            调试委托 委托对象 = new 调试委托();
            MathAction 新委托 = 委托参数 => 委托参数 * 1;
            MathAction 新委托2 = 委托对象.返回双精度浮点数的方法;

            新委托2(2);

            var 委托方法 = 新委托.Method;
            var 委托方法2 = 新委托2.Method;


        }




        //为什么要使用委托

        //委托分为哪些
    }


    //申明一个委托
    delegate double MathAction(double num);


    public static class DelegateTest
    {

        public static double Double(double input)
        {
            return input * 2;
        }

    }



    class 调试委托
    {
        public double 返回双精度浮点数的方法(double 参数)
        {

            return 参数 * 参数;
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 委托_action
    {
        //Action<T>
        //封装一个方法，该方法只有参数不反悔值

        public void 示例()
        {
            List<String> names = new List<string>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            //调用带名字的函数
            //     names.ForEach(Print);

            //匿名函数
            //  names.ForEach(delegate(string s) { Print(s); });

            //lambda 表达式
            //names.ForEach(s => Console.WriteLine(s));
            names.TrueForAll(w => w.Length==3);
            names.Where(w => w.Length == 3);

        }


        public void 实例带3个参数的action()
        {
            //string 


        }




        private void Print(string s)
        {
            Console.WriteLine(s);
        }

    }

    public class TestAction
    {

        public void Test()
        {
            Action<string> messageTrrget;
            if (Environment.GetCommandLineArgs().Length > 1)
                messageTrrget = ShowWindowsMessage;
            else
                messageTrrget = Console.WriteLine;

            messageTrrget("Hello ,Word!");

        }

        private void ShowWindowsMessage(string message)
        {
            Console.WriteLine(message);
        }


        public void Test_匿名方法()
        {
            Action<string> messageTarget;
            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = delegate(string s) { ShowWindowsMessage(s); };
            else
                messageTarget = delegate(string s) { Console.WriteLine(s); };

            messageTarget(" Hello,World!");

        }


        public void Test_lambda()
        {
            Action<string> messageTarget;
            if (Environment.GetCommandLineArgs().Length > 1)
                messageTarget = s => ShowWindowsMessage(s);
            else
                messageTarget = s => Console.WriteLine(s);
            messageTarget("Hello,World!");

        }
    }
}

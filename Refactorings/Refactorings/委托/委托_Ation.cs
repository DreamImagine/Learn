using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Refactorings
{
    public class 委托_Ation
    {

        //封装一个方法，该方法不具有参数并且不返回值

        public void 使用Action委托()
        {
            Name testName = new Name("Koani");
            Action showMethod = testName.DisplayToWindow;
            showMethod();
        }


   
    }


    public class Name
    {
        private string instanceName;

        public Name(string name)
        {
            this.instanceName = name;
        }

        public void DisplayToConsolw()
        {
            Console.WriteLine(this.instanceName);
        }

        public void DisplayToWindow()
        {

            Console.WriteLine("window{0}", this.instanceName);
        }



    }



}

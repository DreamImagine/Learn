using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.设计模式
{
    /// <summary>
    /// 
    /// </summary>
    public class 工厂模式_Factory
    {
        public static Samole creator(int which)
        {
            if (which == 1)
            {
                return new SampleA();
            }
            else if (which == 2)
            {
                return new SampleB();
            }

            return new Samole();
        }
    }

    public class Samole:MySample
    {

    }


    public class SampleA : Samole
    {

    }

    public class SampleB : Samole
    {

    }

    public class MySample
    {

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Refactorings;
using Refactorings.Systems;
using System.Security.Permissions;
using Refactorings.委托;
using Refactorings.动态编程;
using Refactorings.并行;
using Refactorings.Files;

namespace ConsoleRefactorings
{
    class Program
    {
        [SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy = true)]
        static void Main(string[] args)
        {

            #region 委托
            // 委托_delegate 搞懂委托 = new 委托_delegate();
            //搞懂委托.delegateTest();

            //委托_Func func = new 委托_Func();
            //func.多个参数();
            //委托_Ation action_委托 = new 委托_Ation();
            //action_委托.使用Action委托();

            //TestAction action_test_委托 = new TestAction();
            //action_test_委托.Test();

            //委托_action _action = new 委托_action();
            //_action.示例();
            #endregion

            #region 匿名函数
            //匿名方法_Lambda 匿名实例类 = new 匿名方法_Lambda();
            //匿名实例类.Test();
            #endregion

            #region
            //DemonstrateAsyncPattern.Main();
            #endregion

            #region 上下文

            //激活_ActivationContext 激活_A = new 激活_ActivationContext();
            //激活_A.开始();
            #endregion

            //委托_AsyncCallback.Main();


            //斜边与逆变
            //协变逆变 斜逆 = new 协变逆变();
            //斜逆.Test();

            #region 反射代码

            // 反射代码 反码 = new 反射代码();
            //// 反码.TypeConstructorInfo();
            // 反码.成员方法字段类型_信息();
            #endregion

            //Task_演示 task = new Task_演示();
            //task.ShowTest();

            //链式编程与扩展 linqs = new 链式编程与扩展();
            //linqs.Test();
            //链式编程 lsbc = new 链式编程();
            //   lsbc.Example2();
            //lsbc.比较();
            //Test tt = new Test();
            //tt.Tests();
            Files1 file = new Files1();
            //file.Test();
            file.Test();
        }

    }

    public class AB
    {
        public int Id { get; set; }
    }

    public class Test
    {

        public void Tests()
        {
            string 测试 = "a";
            int count = 0;
            AB a = new AB();
            IList<AB> list;

            News(a, 测试, ref  count, out list);
            Console.WriteLine(a.Id);
            Console.WriteLine(测试);
            Console.WriteLine(count);

            Console.WriteLine();
            foreach (var item in list)
            {
                Console.WriteLine(item.Id);
            }

        }
        private void News(AB ab, string b, ref int count, out IList<AB> list)
        {
            list = new List<AB>();
            ab.Id = 10;
            b = "引用类型";
            count = 20;
            list.Add(new AB { Id = 1 });
            list.Add(new AB { Id = 2 });
            list.Add(new AB { Id = 3 });
        }
    }
}

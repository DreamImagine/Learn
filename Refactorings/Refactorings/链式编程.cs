using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 链式编程
    {
        public void Example2()
        {
            Person person = new Person { Name = "Tome" }.Run().Sing().Swim();


        }



        public void 比较()
        {
            Person person = new Person { Name = "Tome" }.Run().Sing().Swim().Run()
                .Sing()
                .Swim();

            //常规代码
            Person person2 = new Person();
            person2.Run();
            person2.Sing();
            person2.Swim();
            person2.Run();
            person2.Sing();
            person2.Swim();

            Console.WriteLine();
            int nums = person.ReturnInt(10).ReturnInt(12);
            Console.WriteLine();
            Console.WriteLine("returnInt:{0}",nums);
        }


        public void Test()
        {
            new Student { Name = "fff" }.Do(w => w.Run());

            //new Student{ Name="ddd"}.ReturnThis<Student>(w=>w.)
        }

    }

    public class Person
    {
        public string Name { get; set; }

        public Person Run()
        {
            Console.WriteLine("run");
            return this;
        }

        public Person Swim()
        {
            Console.WriteLine("Swin");
            return this;
        }

        public Person Sing()
        {
            Console.WriteLine("Sing");
            return this;
        }


    }

    public class Student
    {
        public string Name { get; set; }
        public void Run() { Console.WriteLine("Run"); }
        public void Swin() { Console.WriteLine("Swin"); }
        public void Sing() { Console.WriteLine("Sing"); }

    }


  
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//需要类库
using System.Reflection;

using System.IO;


namespace Refactorings.动态编程
{
    public class 反射
    {
        //
        //程序集包含模块 ，而模块包含类型，类型又包含成员.
        // 反射提供了封装程序集，模块，和类型的对象。
        //可以使用反射动态的创建类型的实例，将类型绑定到现有对象或从现有对象中获取类型。
        //然后可以通过调用类型的方法或访问其字段和属性。
        //反射通常用途如下：
        //使用Assembly定义加载程序集，加载程序集清单中列出模块，以及从程序集中查找类型并创建该类型的实例。

        //使用Module 发现一下信息：包含模块的程序集以及模块中的类等，
        //还可以获取在模块上定义所有全局方法或其他特定非全局方法。

        //使用ConstrunctorInfo 发现： 
        //构造函数的名称，参数，访问修饰符（如public  或privete）
        //和实现详情信息（abstract 或 virtual）等，
        //使用Type的GetConstructors 或GetConstructor 方法来调用特定的构造函数。

        //使用MethodInfo 发以下下信息：
        //方法名称，返回类型，参数，访问修饰符（如public 或private）和实现详情信息
        //（abstract 或 virtual）等，使用Type的GetMethods 或GetMethod 方法来调用特定的方法。
        //使用FieldInfo 发现以下信息;字段名称，访问修饰符(public 或 priveate)和实现详情西悉尼(如static )等;
        // 并获取或设置字段值。

        //使用EventInfo 发现如下信息:事件名称，时间处理程序数据类型，自定义特性，声明类型和反射类型等;
        //并添加或移除事件处理程序。

        //使用PropertyInfo 发现以下信息：属性的明，数据类型，声明类型，反射类型，和只读或可写状态等;
        //并获取或设置属性值。

        //ParameterInfo 发现以下信息：参数的名称，数据类型，参数是输入参数还是输出参数，以及参数在方法签名中的位置等。


        //当在一个应用程序域的仅反射上下文中工作时，请使用CustomAttributerData 来发现有关自定义特性的信息。
        //通过使用CustomAttributeData ，您不必创建特性的实例就可以检查它们。


        //system.Refaection.Emit 命名空间的类提供了一种特殊形式的反射，使我能够在运行时生成类型。


    }

    public class 反射中的运行类型
    {
        //反射提供类（例如Type 和 MethodInfo） 来表示类型，成员，参数和其他代码实体。
        //但是，在使用反射时，并不直接使用这些类，
        //这些类中的大多数都是抽象的，使用的是公共语言运行时（clr）提供的类型。

        //例如：使用C#的typeof 运算符获取Type对象时，该对象实际上是RuntimeType.
        //RuntimeType派生自Type ，并提供所有抽象方法的基础。

        //这些运行时类是internal ，它们的文档 与它们的基类的文档并没有分开，因为它们的行为是由
        //基类文档描述的。






    }

    public class 反射代码
    {

        //system.type 类对于反射起着核心的作用，当反射请求加载的类型时，公共语言运行时将为它创建一个Type.
        //您可以使用Type对象的方法，字段，属性和嵌套类来查询有关该类型的所有信息。


        //使用Assembly.GetType或Assembly.GetTypes从尚未加载的程序集中获取Type对象，
        //并传入所需类型的名称，使用Type.GetType可以从已加载的程序集中获取Type对象，使用
        //Module.GetTypes可以获取模块Type对象。
        public void 查看类型信息()
        {
            //在程序集的Assenbly对象和模块时所必需的语法
            Assembly a = typeof(object).Module.Assembly;


            //从一家在的程序集中获取Type对象
            Assembly a2 = Assembly.LoadFrom("myExe.exe");
            Type[] types2 = a2.GetTypes();
            foreach (Type item in types2)
            {
                Console.WriteLine(item.FullName);
            }

            //在获取一个Type后，您可以采用许多方法来发现与该类型的成员有关的信息。
            //
            //例如，通过调用Type.GetMembers方法（该方法讲获取对当前类型的每个成员进行描述的一组MemberInfo对象）。

            //

        }


        public void TypeConstructorInfo()
        {
            Type t = typeof(String);
            Console.WriteLine("Listing all the public constructors of the {0} type", t);
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("//Construcors");
            PrintMembers(ci);
        }


        public void PrintMembers(MemberInfo[] ms)
        {
            foreach (MemberInfo item in ms)
            {
                Console.WriteLine("{0}{1}", "    ", item);
            }
            Console.WriteLine();
        }



        public void 成员方法字段类型_信息()
        {
            Console.WriteLine("\n Reflection.MemberInfo");
            Type myType = Type.GetType("System.IO.File");
            MemberInfo[] Mymemberinfoarray = myType.GetMembers();

            Console.WriteLine("\n There are{0} members in {1}",
                Mymemberinfoarray.Length,
                myType.FullName);

            Console.WriteLine("{0}", myType.FullName);
            if (myType.IsPublic)
            {
                Console.WriteLine("{0}is public ", myType.FullName);
            }
        }


        public void 反射_MemberInfo()
        {
            Console.WriteLine("Reflection.MethodInfo");

            Type MyType = Type.GetType("System.Reflection.FieldInfo");

            MethodInfo MymethodInfo = MyType.GetMethod("GetValue");
            Console.WriteLine(MyType.FullName + "." + MymethodInfo.Name);
            MemberTypes Mymembertypes = MymethodInfo.MemberType;
            if (MemberTypes.Constructor == Mymembertypes)
            {
                Console.WriteLine("Member typeis of type All");
            }
            else if (MemberTypes.Custom == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Event");
            }
            else if (MemberTypes.Property == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type Property ");
            }
            else if (MemberTypes.TypeInfo == Mymembertypes)
            {
                Console.WriteLine("MemberType is of type TypeInfo");
            }
        }

    }
}

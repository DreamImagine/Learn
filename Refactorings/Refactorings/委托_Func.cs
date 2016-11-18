using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 委托_Func
    {
        //封装一个具有一个参数并返回TResult参数指定的类型值得方法。

        Func<string, string> func_String = s => s.ToUpper();


        // in T
        //此类型封装的方法是参数类型
        //此类型参数是逆变，即可以使用指定的类型或派生成都更低的类型。

        //out TResult
        // 此委托封装的方法是返回值类型。
        //此类型参数是协变，即可以使用指定的类型或派生程度更高的类型。

        //arg
        //类型：T
        //此委托封装的方法的参数



        public void Func_show()
        {

            Func<string, string> selector = str => str.ToUpper();

            string[] words = { "orange", "apple", "Article", "elephant" };

            IEnumerable<String> aWords = words.Select(selector);

            foreach (string item in aWords)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// 2个参数
        /// </summary>
        public void Func_show_2()
        {
            Func<string, int, string[]> extractMethod = ExtractWords;
            string title = "The Scarlet Letter";
            foreach (string item in extractMethod(title, 2))
                Console.WriteLine(item);
        }


        public string[] ExtractWords(string p1, int p2)
        {
            char[] delimiters = new char[] { ' ' };
            if (p2 > 0)
                return p1.Split(delimiters, p2);
            else
                return p1.Split(delimiters);
        }

        public void Func_show_2_匿名函数()
        {
            Func<string, int, string[]> extractMeth = delegate(string s, int i)
            {
                char[] delimiters = new char[] { ' ' };
                return i > 0 ? s.Split(delimiters, i) : s.Split(delimiters);
            };

        }

        public void Func_show_lambda()
        {
            char[] separators = new char[] { ' ' };
            Func<string, int, string[]> extractMeth = (s1, s2) => s2 > 0 ? s1.Split(separators, s2) : s1.Split(separators);
            string title = "The Scarlet Letter";
            foreach (string item in extractMeth(title, 5))
                Console.WriteLine(item);

        }

        public void 多个参数()
        {
            Func<string, int, bool> predicate = (str, index) => { Console.WriteLine("str:{0},index:{1},{2},", str.Length, index, str); return str.Length == index; };
            String[] words = { "orange", "apple", "Article", "elephant", "star", "and" };
            IEnumerable<String> aWords = words.Where(predicate).Select(str => str);

            IEnumerable<String> aWords2 = words.Where(predicate).ToList();

            foreach (var item in aWords)
            {
                Console.WriteLine("a+\n");
                Console.WriteLine(item);
            }

            Console.WriteLine("\n");
            foreach (var item in aWords2)
            {
                Console.WriteLine(item);
            }
        }
    }
}

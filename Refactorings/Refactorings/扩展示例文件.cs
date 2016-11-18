using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public static class 扩展示例文件
    {

        /// <summary>
        /// 扩展无返回类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static T Do<T>(this T t, Action<T> action)
        {
            action(t);
            return t;

        }

        public static T ReturnThis<T>(this T t, Func<int, T> wheres)
        {
            return t;
        }

        public static int ReturnInt<T>(this T t, int intNumber)
        {
            return intNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="soure"></param>
        /// <param name="predicate">where查询条件</param>
        /// <param name="condition">判断条件</param>
        /// <returns></returns>
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> soure, Expression<Func<T, bool>> predicate, bool condition)
        {
            return condition ? soure.Where(predicate) : soure;
        }


        /// <summary>
        /// 扩展String 方法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

    }
}

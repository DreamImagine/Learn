using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.扩展
{
    public static class Helper
    {


        /// <summary>
        /// 字符串转换成byte
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte ToByte(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            var intVal = int.Parse(val);

            return (byte)intVal;
        }

        /// <summary>
        /// 字符串转换成int16
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static short ToInt16(this string val)
        {
            if (string.IsNullOrEmpty(val))
            {
                return 0;
            }
            var intVal = int.Parse(val);

            return (short)intVal;
        }

        /// <summary>
        /// 字符串是否为空
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNull(this string val)
        {
            return string.IsNullOrEmpty(val);
        }


        /// <summary>
        /// 字符串是不为空，有值状态
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNotNull(this string val)
        {
            return !string.IsNullOrEmpty(val);
        }



        /// <summary>
		///     Md5加密函数
		/// </summary>
		/// <param name="strPwd"></param>
		/// <returns></returns>
		public static string Encrypt(string strPwd)
        {
            var md5Hasher = MD5.Create();

            var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(strPwd)); //将字符编码为一个字节序列 

            var sBuilder = new StringBuilder(); //计算data字节数组的哈希值

            foreach (var @byte in data)
            {
                sBuilder.Append(@byte.ToString("x2"));
            }

            return sBuilder.ToString();
        }


        /// <summary>
        /// 集合数据转成 DataSet
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ToDataSet<TSource>(this IList<TSource> list)
        {
            Type elementType = typeof(TSource);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            foreach (var pi in elementType.GetProperties())
            {
                Type colType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                dt.Columns.Add(pi.Name, colType);
            }

            foreach (TSource item in list)
            {
                DataRow row = dt.NewRow();
                foreach (var pi in elementType.GetProperties())
                {
                    row[pi.Name] = pi.GetValue(item, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataSet ToDataSet<TSource>(this ICollection<TSource> list)
        {
            Type elementType = typeof(TSource);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            ds.Tables.Add(dt);

            foreach (var pi in elementType.GetProperties())
            {
                Type colType = Nullable.GetUnderlyingType(pi.PropertyType) ?? pi.PropertyType;
                dt.Columns.Add(pi.Name, colType);
            }

            foreach (TSource item in list)
            {
                DataRow row = dt.NewRow();
                foreach (var pi in elementType.GetProperties())
                {
                    row[pi.Name] = pi.GetValue(item, null) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return ds;
        }



        /// <summary>
        /// 枚举扩展函数
        /// <para>把枚举转换成对应的byte 类型，再转换成String</para>
        /// </summary>
        /// <param name="en"></param>
        /// <returns></returns>
        public static string ToByteString(this Enum en)
        {
            return ((byte)(dynamic)en).ToString();
        }

    }
}

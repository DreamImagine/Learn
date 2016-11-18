using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings
{
    public class 链式编程与扩展
    {

        public void Test()
        {
            DataStream data = new DataStream();
            IMechine<DataStream> mnode = new Mechine1<DataStream>();
            mnode.execute().Append(new Mechine2<DataStream>()).execute();
        }


    }

    public class DataStream
    {
        public string Status { get; set; }
    }


    public interface IMechine<T> where T : class
    {
        T Data { get; set; }
        IMechine<T> Append(IMechine<T> next);
        IMechine<T> execute();

    }


    public abstract class MechineNode<T> : IMechine<T> where T : DataStream, new()
    {
        public IMechine<T> Next { get; set; }
        public abstract IMechine<T> execute();

        public T Data { get; set; }

        public IMechine<T> Append(IMechine<T> next)
        {
            this.Next = next;
            next.Data = this.Data;
            return next;
        }
    }

    public sealed class Mechine1<T> : MechineNode<T> where T : DataStream, new()
    {
        public override IMechine<T> execute()
        {
            this.Data.Status = "updated by mechine 1";
            return this;
        }
    }


    /// <summary>
    /// 机器节点2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class Mechine2<T> : MechineNode<T> where T : DataStream, new()
    {
        public override IMechine<T> execute()
        {
            this.Data.Status += ",updated by mechine 2";

            return this;
        }
    }
}

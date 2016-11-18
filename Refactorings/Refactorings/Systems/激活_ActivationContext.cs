using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.Systems
{
    /// <summary>
    /// 标识当前应用程序的激活上下文。
    /// </summary>
  
    public class 激活_ActivationContext
    {
        [SecurityPermission(SecurityAction.LinkDemand,ControlDomainPolicy=true)]
        public void 开始()
        {
            //ActivationContext ac = AppDomain.CurrentDomain.ActivationContext;
            //ApplicationIdentity ai = ac.Identity;
            //Console.WriteLine("full Name"+ai.FullName);
            //Console.WriteLine("code name:"+ai.CodeBase);
            //Console.Read();

        }
    }
}

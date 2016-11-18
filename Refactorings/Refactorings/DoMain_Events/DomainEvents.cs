using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactorings.DoMain_Events
{
    public class DomainEvents
    {
    }


    public interface IDomainEvent
    {

    }

    public class CustomerBecamPreferred : IDomainEvent
    {
        public Customer Customer { get; set; }
    }

    public class Customer{

        public void DoSomething()
        {
            
        }
    }
}

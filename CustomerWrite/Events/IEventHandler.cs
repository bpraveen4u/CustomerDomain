using CustomerWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public interface IEventHandler
    {
        Task<Customer> ListenForCustomerCreatedEvent(CustomerCreatedEvent createdEvent);
    }
}

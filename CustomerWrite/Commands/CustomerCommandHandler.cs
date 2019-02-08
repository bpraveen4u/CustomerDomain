using CustomerWrite.Events;
using CustomerWrite.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDomain.Commands
{
    public class CustomerCommandHandler : ICommandHandler
    {
        private ICustomerRepository customerRepository;
        private readonly IEventHandler eventHandler;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEventHandler eventHandler)
        {
            this.customerRepository = customerRepository;
            this.eventHandler = eventHandler;
        }

        //public Task ListenForCustomerCreatedCommand(CreateCustomerCommand createCustomer)
        //{
        //    var eventObject = createCustomer.ToCustomerCreatedEvent();
        //    var id = 
        //}
    }
}

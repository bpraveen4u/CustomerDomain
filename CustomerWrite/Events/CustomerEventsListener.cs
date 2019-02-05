using CustomerWrite.Models;
using CustomerWrite.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Events
{
    public class CustomerEventsListener : IEventHandler
    {
        private readonly ICustomerRepository repo;
        private readonly ServiceBusQueueEvents eventSender;

        public CustomerEventsListener(ICustomerRepository repo, IConfiguration config)
        {
            this.repo = repo;
            eventSender = new ServiceBusQueueEvents(config);
        }

        public async Task<Customer> ListenForCustomerCreatedEvent(CustomerCreatedEvent createdEvent)
        {
            var cust = createdEvent.ToCustomerModel();
            var result = await this.repo.AddCustomer(cust);
            createdEvent.Id = result.Id;
            cust.Id = result.Id;
            await eventSender.SendEventsToQueue(createdEvent);
            return cust;
        }
    }
}

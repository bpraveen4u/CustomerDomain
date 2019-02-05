using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Events;
using CustomerWrite.Models;
using CustomerWrite.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWrite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IEventHandler eventHandler;

        //public ICustomerRepository repo;

        //public CustomersController(ICustomerRepository repository)
        //{
        //    //this.repo = new CustomerMemoryRepository();
        //    this.repo = repository;
        //}

        public CustomersController(IEventHandler eventHandler)
        {
            this.eventHandler = eventHandler;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Customer>> Post([FromBody] Customer value)
        {
            CustomerCreatedEvent customerCreatedEvent = new CustomerCreatedEvent()
            {
                Id = value.Id,
                Name = value.Name,
                Address = value.Address,
                Phone = value.Phone
            };

            var cust = await eventHandler.ListenForCustomerCreatedEvent(customerCreatedEvent);
            return Ok(cust);
        }
    }
}

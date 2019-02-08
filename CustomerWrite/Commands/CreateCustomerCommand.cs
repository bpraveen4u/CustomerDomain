using CustomerWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerDomain.Commands
{
    public class CreateCustomerCommand : ICommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Customer ToCustomerCreatedEvent()
        {
            return new Customer()
            {
                Id = this.Id,
                Name = this.Name,
                Address = this.Address,
                Phone = this.Phone
            };
        }
    }
}

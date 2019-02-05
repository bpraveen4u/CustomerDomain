using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerWrite.Models;

namespace CustomerWrite.Repository
{
    public class SqlCustomerRepository : ICustomerRepository
    {
        private readonly CustomerDomainContext _context;
        public SqlCustomerRepository(CustomerDomainContext context)
        {
            this._context = context;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            this._context.Customers.Add(customer);
            await this._context.SaveChangesAsync();
            return customer;
        }

        public Task<ICollection<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}

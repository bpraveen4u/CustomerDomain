using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDomain.Models;

namespace CustomerDomain
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

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            return await Task.FromResult(this._context.Customers.ToList());
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await Task.FromResult(this._context.Customers.FirstOrDefault(c => c.Id == id));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDomain.Models;

namespace CustomerDomain
{
    public class CustomerMemoryRepository : ICustomerRepository
    {
        private static readonly List<Customer> repo;
        static int counter = 0;

        static CustomerMemoryRepository()
        {
            repo = new List<Customer>();
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            counter++;
            customer.Id = counter;
            repo.Add(customer);
            return await Task.FromResult(customer);
        }

        public async Task<ICollection<Customer>> GetAllCustomers()
        {
            return await Task.FromResult(repo);
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await Task.FromResult(repo.FirstOrDefault(c => c.Id == id));
        }
    }
}

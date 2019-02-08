using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerDomain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDomain.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        public ICustomerRepository repo;

        public CustomersController(ICustomerRepository repository)
        {
            //this.repo = new CustomerMemoryRepository();
            this.repo = repository;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return Ok(this.repo.GetAllCustomers().Result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(this.repo.GetCustomer(id).Result);
        }

        // POST api/values
        //[HttpPost]
        //public ActionResult<Customer> Post([FromBody] Customer value)
        //{
        //    return Ok(this.repo.AddCustomer(value).Result);
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

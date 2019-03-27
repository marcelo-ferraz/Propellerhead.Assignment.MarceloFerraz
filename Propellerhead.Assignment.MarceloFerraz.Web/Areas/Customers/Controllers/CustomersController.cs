using Microsoft.AspNetCore.Mvc;
using PassOn;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data;
using Propellerhead.Assignment.MarceloFerraz.Web.Areas.Customers.Models;
using Propellerhead.Assignment.MarceloFerraz.Web.Commons;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Propellerhead.Assignment.MarceloFerraz.Web.Areas.Customers.Controllers
{
    using BusinessCustomer = Core.Customers.Models.Customer;

    [Route("api/customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService customerService;
        private readonly ICustomerRepository customerRepository;
        
        public CustomersController(
            ICustomerService customerService,
            ICustomerRepository customerRepository)
        {
            this.customerService = customerService;
            this.customerRepository = customerRepository;
        }

        // GET api/customers/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return customerRepository
                .Get(id)
                .To<Customer>();
        }

        // POST api/customers
        [HttpPost]
        public NewIdResponse Post([FromBody]Customer model)
        {
            var id = customerService.Create(
                model.To<BusinessCustomer>());

            return new NewIdResponse (id);
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Customer model)
        {
            var customer = 
                new BusinessCustomer { Id = id };

            Pass.Onto(model, customer);

            customerService.Update(customer);
        }
    }
}

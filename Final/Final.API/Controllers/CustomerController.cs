using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.ApplicationCore.Model.Request;
using Final.ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        //[Authorize]
        [HttpGet]
        //[Authorize]
        [Route("all")]
        public async Task<IActionResult> ListAllCustomer()
        {
            var customers = await _customerService.ListAll();
            if (!customers.Any())
            {
                return NotFound(" No customers are found. Please add customers first.");
            }
            return Ok(customers);
        }
        //[Authorize]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddCustomer(CustomerRegisterRequestModel customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");

            }
            var registeredCustomer = await _customerService.AddCustomer(customer);
            return Ok(registeredCustomer);

        }
        //[Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Not found target customer with id:" + id);
            }
            return Ok(customer);
        }

        //[Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var client = await _customerService.GetCustomerById(id);
            await _customerService.DeleteCustomerById(id);
            return Ok();
        }
        //[Authorize]
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerRegisterRequestModel customer)
        {
            await _customerService.UpdateCustomer(id, customer);
            return Ok();

        }



    }
}

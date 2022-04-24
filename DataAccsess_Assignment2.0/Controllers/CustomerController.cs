using DataAccsess_Assignment2._0.Models;
using DataAccsess_Assignment2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccsess_Assignment2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(CustomerModel customer)
        {
            var result = await _service.PostAsync(customer);
            if (result != null)
            {
                return new OkObjectResult(result);
            }

            return new BadRequestResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerEntity(int id, CustomerModel customerEntity)
        {
            var item = await _service.UpdateCustomerAsync(id, customerEntity);
            if (item != null)
                return new OkObjectResult(item);

            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GettAll()
        {
            return new OkObjectResult(await _service.GetAllAsync());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _service.DeleteAsync(id))
                return new NoContentResult();

            return new NotFoundResult();
        }
    }
}

using DataAccsess_Assignment2._0.Data;
using DataAccsess_Assignment2._0.Models;
using DataAccsess_Assignment2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccsess_Assignment2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IOrderService _service;

        public OrderController(DataContext context, IOrderService service)
        {
            _context = context;
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer(OrderModel order)
        {
            var result = await _context.AddAsync(order);
            if (result != null)
            {
                return new OkObjectResult(result);
            }

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

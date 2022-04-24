using DataAccsess_Assignment2._0.Data;
using DataAccsess_Assignment2._0.Models;
using DataAccsess_Assignment2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataAccsess_Assignment2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductModel product)
        {
            var result = await _service.PostAsync(product);
            if (result != null)
            {
                return new OkObjectResult(result);
            }

            return new BadRequestResult();
        }

        [HttpPut("{id")]
        public async Task<ActionResult> UpdateProduct(int id, ProductModel product)
        {
            var item = await _service.UpdateProductAsync(id, product);
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

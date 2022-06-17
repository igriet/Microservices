using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Interface;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var product = await _repository.GetAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
    }
}

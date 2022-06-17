using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sale.Interface;

namespace Sale.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly IOrderRepository _repository;

        public SaleController(IOrderRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var orders = await _repository.GetAsync(id);
            if (orders == null)
                return NotFound();
            return Ok(orders);
        }
    }
}

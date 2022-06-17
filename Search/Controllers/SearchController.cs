using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Search.Interface;

namespace Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IProductService _productService;
        private readonly ISaleService _saleService;

        public SearchController(IClientService clientService, IProductService productService, ISaleService saleService)
        {
            _clientService = clientService;
            _productService = productService;
            _saleService = saleService;
        }

        [HttpGet("client/{clientId}")]
        public async Task<IActionResult> SearchAsync(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                return BadRequest();

            try
            {
                var client = await _clientService.GetClientAsync(clientId);
                var sales = await _saleService.GetSaleAsync(clientId);

                foreach(var sale in sales)
                {
                    foreach(var item in sale.Items)
                    {
                        var product = await _productService.GetProductAsync(item.ProductId);
                        item.Product = product;
                    }
                }

                var result = new
                {
                    Client = client,
                    Sales = sales
                };

                return Ok(result);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

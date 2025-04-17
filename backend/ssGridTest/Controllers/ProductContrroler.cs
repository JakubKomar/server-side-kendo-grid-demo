using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using ssGridTest.Dto;
using ssGridTest.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace ssGridTest.Controllers
{
    /// <summary>
    /// Kontroler pro produkty
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductContrroler : ControllerBase
    {
        readonly IProductService _productService;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="productService"></param>
        public ProductContrroler(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Získá všechny produkty
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(DataSourceResultDoc<ProductDto>))]
        [HttpGet]
        public async Task<IActionResult> GetAll([DataSourceRequest] DataSourceRequest request) =>
            Ok(await _productService.GetProductsAsync(request));

    }
}


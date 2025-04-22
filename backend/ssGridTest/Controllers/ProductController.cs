using GridSeverSideDemo.Dto;
using GridSeverSideDemo.Services;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace GridSeverSideDemo.Controllers
{
    /// <summary>
    /// Kontroler pro produkty
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService _productService;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="productService"></param>
        public ProductController(IProductService productService)
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


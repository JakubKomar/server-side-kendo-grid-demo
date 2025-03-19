
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static ssGridTest.Controllers.TestGrid;

namespace ssGridTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestGrid : ControllerBase
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public DateTime AddedDate { get; set; }
            public string Brand { get; set; }
        }

        List<Product> products = new()
        {
                new Product { Id = 1, Name = "iPhone 13 Ultra", Price = 1299, AddedDate = DateTime.Now.AddDays(-1), Brand = "Apple" },
                new Product { Id = 2, Name = "Galaxy S22 Pro", Price = 999, AddedDate = DateTime.Now.AddDays(-2), Brand = "Samsung" },
                new Product { Id = 3, Name = "Pixel 7 Pro", Price = 899, AddedDate = DateTime.Now.AddDays(-3), Brand = "Google" },
                new Product { Id = 4, Name = "Xperia Z5", Price = 799, AddedDate = DateTime.Now.AddDays(-4), Brand = "Sony" },
                new Product { Id = 5, Name = "Mi 12 Ultra", Price = 699, AddedDate = DateTime.Now.AddDays(-5), Brand = "Xiaomi" },
                new Product { Id = 6, Name = "OnePlus 11T", Price = 749, AddedDate = DateTime.Now.AddDays(-6), Brand = "OnePlus" },
                new Product { Id = 7, Name = "Moto Edge 30", Price = 679, AddedDate = DateTime.Now.AddDays(-7), Brand = "Motorola" },
                new Product { Id = 8, Name = "Oppo Find X5", Price = 859, AddedDate = DateTime.Now.AddDays(-8), Brand = "Oppo" },
                new Product { Id = 9, Name = "Vivo X80 Pro", Price = 829, AddedDate = DateTime.Now.AddDays(-9), Brand = "Vivo" },
                new Product { Id = 10, Name = "Asus ROG Phone 6", Price = 999, AddedDate = DateTime.Now.AddDays(-10), Brand = "Asus" },
                new Product { Id = 11, Name = "Nokia XR20", Price = 499, AddedDate = DateTime.Now.AddDays(-11), Brand = "Nokia" },
                new Product { Id = 12, Name = "Honor Magic 4", Price = 759, AddedDate = DateTime.Now.AddDays(-12), Brand = "Honor" },
                new Product { Id = 13, Name = "Realme GT Neo 3", Price = 599, AddedDate = DateTime.Now.AddDays(-13), Brand = "Realme" },
                new Product { Id = 14, Name = "Redmi Note 11 Pro", Price = 329, AddedDate = DateTime.Now.AddDays(-14), Brand = "Redmi" },
                new Product { Id = 15, Name = "Sony WH-1000XM5", Price = 349, AddedDate = DateTime.Now.AddDays(-15), Brand = "Sony" },
                new Product { Id = 16, Name = "Beats Studio 3", Price = 299, AddedDate = DateTime.Now.AddDays(-16), Brand = "Beats" },
                new Product { Id = 17, Name = "JBL Flip 6", Price = 129, AddedDate = DateTime.Now.AddDays(-17), Brand = "JBL" },
                new Product { Id = 18, Name = "Bose QuietComfort 45", Price = 329, AddedDate = DateTime.Now.AddDays(-18), Brand = "Bose" },
                new Product { Id = 19, Name = "HP Envy x360", Price = 1099, AddedDate = DateTime.Now.AddDays(-19), Brand = "HP" },
                new Product { Id = 20, Name = "Dell XPS 15", Price = 1499, AddedDate = DateTime.Now.AddDays(-20), Brand = "Dell" }
            };

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpPost]
        public IActionResult GetProducts([DataSourceRequest] DataSourceRequest request)
        {
            List<Product> ls = products.ToDataSourceResult(request).Data.Cast<Product>().ToList();

            return Ok(ls);
        }
    }


}


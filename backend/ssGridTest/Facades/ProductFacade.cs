using ssGridTest.Ef;

namespace ssGridTest.Facades
{
    public class ProductFacade : IProductFacade
    {
        private static List<Product> products = new()
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
            new Product { Id = 20, Name = "Dell XPS 15", Price = 1499, AddedDate = DateTime.Now.AddDays(-20), Brand = "Dell" },
            new Product { Id = 21, Name = "Lenovo ThinkPad X1 Carbon", Price = 1599, AddedDate = DateTime.Now.AddDays(-21), Brand = "Lenovo" },
            new Product { Id = 22, Name = "Acer Predator Helios 300", Price = 1299, AddedDate = DateTime.Now.AddDays(-22), Brand = "Acer" },
            new Product { Id = 23, Name = "Razer Blade 15", Price = 1999, AddedDate = DateTime.Now.AddDays(-23), Brand = "Razer" },
            new Product { Id = 24, Name = "MSI GS66 Stealth", Price = 1799, AddedDate = DateTime.Now.AddDays(-24), Brand = "MSI" },
            new Product { Id = 25, Name = "Gigabyte Aorus 15G", Price = 1699, AddedDate = DateTime.Now.AddDays(-25), Brand = "Gigabyte" },
            new Product { Id = 26, Name = "Alienware M15 R7", Price = 1899, AddedDate = DateTime.Now.AddDays(-26), Brand = "Alienware" },
            new Product { Id = 27, Name = "Microsoft Surface Laptop 4", Price = 1399, AddedDate = DateTime.Now.AddDays(-27), Brand = "Microsoft" },
            new Product { Id = 28, Name = "Huawei MateBook X Pro", Price = 1299, AddedDate = DateTime.Now.AddDays(-28), Brand = "Huawei" },
            new Product { Id = 29, Name = "Google Pixelbook Go", Price = 999, AddedDate = DateTime.Now.AddDays(-29), Brand = "Google" },
            new Product { Id = 30, Name = "Asus ZenBook 14", Price = 899, AddedDate = DateTime.Now.AddDays(-30), Brand = "Asus" },
            new Product { Id = 31, Name = "Sony Xperia 1 III", Price = 1199, AddedDate = DateTime.Now.AddDays(-31), Brand = "Sony" },
            new Product { Id = 32, Name = "LG Gram 17", Price = 1299, AddedDate = DateTime.Now.AddDays(-32), Brand = "LG" },
            new Product { Id = 33, Name = "Apple MacBook Air M2", Price = 1199, AddedDate = DateTime.Now.AddDays(-33), Brand = "Apple" },
            new Product { Id = 34, Name = "Samsung Galaxy Book Pro", Price = 1099, AddedDate = DateTime.Now.AddDays(-34), Brand = "Samsung" },
            new Product { Id = 35, Name = "Dell Inspiron 14", Price = 699, AddedDate = DateTime.Now.AddDays(-35), Brand = "Dell" },
            new Product { Id = 36, Name = "HP Spectre x360", Price = 1249, AddedDate = DateTime.Now.AddDays(-36), Brand = "HP" },
            new Product { Id = 37, Name = "Acer Swift 3", Price = 649, AddedDate = DateTime.Now.AddDays(-37), Brand = "Acer" },
            new Product { Id = 38, Name = "Lenovo Legion 5", Price = 1149, AddedDate = DateTime.Now.AddDays(-38), Brand = "Lenovo" },
            new Product { Id = 39, Name = "Razer Book 13", Price = 1599, AddedDate = DateTime.Now.AddDays(-39), Brand = "Razer" },
            new Product { Id = 40, Name = "MSI Prestige 14", Price = 999, AddedDate = DateTime.Now.AddDays(-40), Brand = "MSI" },
        };

        /// <summary>
        /// Získá všechny produkty
        /// </summary>
        /// <returns></returns>
        public IQueryable<Product> GetProducts() =>
            products.AsQueryable();

    }
}

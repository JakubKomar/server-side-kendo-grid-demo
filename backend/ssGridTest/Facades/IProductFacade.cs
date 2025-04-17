using ssGridTest.Ef;

namespace ssGridTest.Facades
{
    public interface IProductFacade
    {
        IQueryable<Product> GetProducts();
    }
}
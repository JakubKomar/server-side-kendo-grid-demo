using GridSeverSideDemo.Ef;

namespace GridSeverSideDemo.Facades
{
    public interface IProductFacade
    {
        IQueryable<Product> GetProducts();
    }
}
using Kendo.Mvc.UI;

namespace ssGridTest.Services
{
    public interface IProductService
    {
        Task<DataSourceResult> GetProductsAsync(DataSourceRequest dataSourceRequest);
    }
}
using Kendo.Mvc.UI;

namespace GridSeverSideDemo.Services
{
    public interface IProductService
    {
        Task<DataSourceResult> GetProductsAsync(DataSourceRequest dataSourceRequest);
    }
}
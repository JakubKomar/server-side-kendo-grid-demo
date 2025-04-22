using AutoMapper;
using AutoMapper.QueryableExtensions;
using GridSeverSideDemo.Dto;
using GridSeverSideDemo.Ef;
using GridSeverSideDemo.Facades;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace GridSeverSideDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductFacade _productFacade;
        private readonly MapperConfiguration mapperConfiguration;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="productFacade"></param>
        public ProductService(IProductFacade productFacade)
        {
            _productFacade = productFacade;

            mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
        }

        /// <summary>
        /// Získá všechny produkty a provede query
        /// </summary>
        /// <param name="dataSourceRequest"></param>
        /// <returns></returns>
        public async Task<DataSourceResult> GetProductsAsync(DataSourceRequest dataSourceRequest) =>
             await _productFacade
                .GetProducts()
                .Where(s => s.Id > 0)
                .ProjectTo<ProductDto>(mapperConfiguration)
                .ToDataSourceResultAsync(dataSourceRequest);


        /// <summary>
        /// Maper pro projekci
        /// </summary>
        protected class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<Product, ProductDto>()
                    .ForMember(dest => dest.AddedDate, opt => opt.MapFrom(src => src.AddedDate.ToDateOnly()));
            }
        }
    }
}

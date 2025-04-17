using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using ssGridTest.Dto;
using ssGridTest.Ef;
using ssGridTest.Facades;

namespace ssGridTest.Services
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

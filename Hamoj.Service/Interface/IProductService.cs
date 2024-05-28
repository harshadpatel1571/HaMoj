

using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();

    Task<ProductDto> AddEditProduct(ProductDto dto);
}

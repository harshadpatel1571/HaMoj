using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface ICatagoryService
{
    Task<List<CatrgoryDto>> GetAllAsync();
}

using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface ICatagoryService
{
    Task<List<CatrgoryDto>> GetAllAsync();

    Task<CatrgoryDto> AddEditCategory(CatrgoryDto dto);

    Task<CatrgoryDto> GetDataById(int id);
    Task<bool> Delete(int id);

    
}

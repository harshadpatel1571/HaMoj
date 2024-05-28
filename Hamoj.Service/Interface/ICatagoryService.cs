using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface ICatagoryService
{
    Task<List<CategoryDto>> GetAllAsync();

    Task<CategoryDto> AddEdit(CategoryDto dto);

    Task<CategoryDto> GetDataById(int id);
    Task<bool> Delete(int id);

    Task<CategoryDto> FindDuplicate(string name, int? id);


}

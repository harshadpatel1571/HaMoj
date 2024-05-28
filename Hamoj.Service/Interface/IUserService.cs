
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();

    Task<UserDto> AddEdit(UserDto dto);

    Task<UserDto> GetDataById(int id);
    Task<bool> Delete(int id);
    Task<UserDto> FindDuplicate(string Email,int? id);



}

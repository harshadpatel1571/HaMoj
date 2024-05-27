
using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
}



using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface ILoginService
{
    Task<UserDto> GetDataById(LoginDto dto);
}



using Hamoj.Service.Dto;

namespace Hamoj.Service.Interface;

public interface ILoginService
{
    Task<UserDto> CheakVendorLogin(LoginDto dto);

    Task<UserDto> CheakCustomerLogin(LoginDto dto);

    Task<UserDto> CheakSuperAdminLogin(LoginDto dto);
}

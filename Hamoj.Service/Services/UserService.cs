
using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;

namespace Hamoj.Service.Services;

public class UserService : IUserService
{
    private readonly HamojDBContext _context;

    public UserService(HamojDBContext context)
    {
        _context = context;
    }
    public Task<List<UserDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}

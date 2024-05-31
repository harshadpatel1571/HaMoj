

using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Hamoj.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly HamojDBContext _context;

        public LoginService (HamojDBContext context)
        {
            _context = context;
        }
        public async Task<UserDto> GetDataById(LoginDto dto)
        {
           return await _context.Vendor.Where(x => x.Email == dto.Email && x.Password == dto.Password).Select(x => new UserDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Password = x.Password,
                is_Active = x.is_Active,
                is_Delete = x.is_Delete
            }).FirstOrDefaultAsync();

        }
    }
}

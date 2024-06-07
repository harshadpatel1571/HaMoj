﻿

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

        public LoginService(HamojDBContext context)
        {
            _context = context;
        }

        public async Task<UserDto> CheakCustomerLogin(LoginDto dto)
        {
            return await _context.Customer.Where(y => y.Mobile == dto.MobileNumber && y.Password == dto.Password).Select( y=> new UserDto
            {
                Id = y.Id,
                Name = y.Name,
                MobileNumber = y.Mobile,
                Password = y.Password,
                is_Active = true,
                is_Delete = false,
            }).FirstOrDefaultAsync();
            
        }

        public async Task<UserDto> CheakVendorLogin(LoginDto dto)
        {
           
                return await _context.Vendor.Where(x => x.MobileNumber == dto.MobileNumber && x.Password == dto.Password).Select(x => new UserDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    MobileNumber = x.MobileNumber,
                    Password = x.Password,
                    is_Active = x.is_Active,
                    is_Delete = x.is_Delete
                }).FirstOrDefaultAsync();

        }
    }
}

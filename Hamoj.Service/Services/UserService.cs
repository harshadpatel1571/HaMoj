
using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class UserService : IUserService
{
    private readonly HamojDBContext _context;

    public UserService(HamojDBContext context)
    {
        _context = context;
    }

    public async Task<UserDto> AddEdit(UserDto dto)
    {
        var dbmodel = new User();
        if (dto.Id > 0)
        {
            // Find Specific Data From Database for Cheaking Previous Data 
            dbmodel = _context.User.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new User();
            }
        }
        // Assign Dto Value (Form Value) or User Inserted Value To Table Object Value
        dbmodel.Name = dto.Name;
        dbmodel.MobileNumber = dto.MobileNumber;
        dbmodel.Email = dto.Email;
        dbmodel.Password = dto.Password;
        dbmodel.Role = (int)UserEnum.Admin;
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;
        dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        dbmodel.Create_by = 1;


        if (dto.Id > 0)
        {
            // Update The data 
            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            _context.User.Update(dbmodel);
        }
        else
        {

            // Add Data 
            dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            dbmodel.Create_by = 1;

            _context.User.Add(dbmodel);

        }
        // Save Database Transection
        _context.SaveChanges();

        return dto;
    }

    public async Task<bool> Delete(int id)
    {

        try
        {
           var dbmodel = await _context.User.Where(x=>x.Id == id).FirstOrDefaultAsync();
            _context.User.Remove(dbmodel);
            _context.SaveChanges();
            return true;
        }

        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<UserDto> FindDuplicate(string Email, int? id)
    {

        return await _context.User.Where(x => x.Email == Email && x.Id != id.Value).Select(x => new UserDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Password = x.Password,
        }).FirstOrDefaultAsync();

    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var data=  await _context.User.Select(x => new UserDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Role = x.Role,

        }).ToListAsync();

        return data;
    }

    public async Task<UserDto> GetDataById(int id)
    {
        return await _context.User.Where(x => x.Id == id).Select(x => new UserDto {
            Id = x.Id, 
            Name = x.Name,
            MobileNumber = x.MobileNumber,
            Email = x.Email,
            Role = x.Role,
            Password =x.Password,
            Confirm_Password=x.Password
        }).FirstOrDefaultAsync();

    }
}



using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.DB.Enum;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class CustomerService : ICustomerService
{
    private readonly HamojDBContext _context;

    public CustomerService(HamojDBContext context)
    {
        _context = context;
    }

    public async Task<CustomerDto> AddEditCustomer(CustomerDto dto)
    {
        var dbmodel = new Customer();
        if (dto.Id > 0)
        {
            dbmodel = _context.Customer.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new Customer();
            }
        }

        dbmodel.Id = dto.Id;
        dbmodel.CompanyName = dto.CompanyName;
        dbmodel.Office_No = dto.Office_No;
        dbmodel.Name = dto.Name;
        dbmodel.Email = dto.Email;
        dbmodel.Mobile = dto.Mobile;
        dbmodel.Address = dto.Address;
        dbmodel.City = dto.City;
        dbmodel.State = dto.State;
        dbmodel.Pincode = dto.Pincode;
        dbmodel.Password = dto.Password;
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;
        dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        dbmodel.Create_by = 1;


        if (dto.Id > 0)
        {

            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            _context.Customer.Update(dbmodel);
        }
        else
        {

            dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            dbmodel.Create_by = 1;

            _context.Customer.Add(dbmodel);

        }
        _context.SaveChanges();

        return dto;
    }

   

    public async Task<bool> Delete(int id)
    {
        try
        {
            var dbmodel = await _context.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Customer.Remove(dbmodel);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    public async Task<CustomerDto> FindDuplicate(int? officeNo, string? mobileNo, int? id)
    {
        return await _context.Customer
            .Where(x => (x.Office_No == officeNo || x.Mobile == mobileNo) && x.Id != id.Value)
            .Select(x => new CustomerDto
            {
                Id = x.Id,
                Office_No = x.Office_No,
                Mobile = x.Mobile,
            })
            .FirstOrDefaultAsync();
    }


    public async Task<List<CustomerDto>> GetAllAsync()
    {
        var data = await _context.Customer.Select(x => new CustomerDto
        {
            Id = x.Id,
            Office_No = x.Office_No,
            Name = x.Name,
            Mobile = x.Mobile,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).ToListAsync();

        return data;
    }

    public async Task<CustomerDto> GetDataById(int id)
    {
        return await _context.Customer.Where(x => x.Id == id).Select(x => new CustomerDto
        {
            Id = x.Id,
            CompanyName = x.CompanyName,
            Office_No = x.Office_No,
            Name = x.Name,
            Email = x.Email,
            Mobile = x.Mobile,
            Address = x.Address,
            City = x.City,
            State = x.State,
            Pincode = x.Pincode,
            Password = x.Password,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).FirstOrDefaultAsync();
    }

     public async Task<CustomerDto> CustomerRegister(CustomerDto dto)
    {
        var dbmodel = new Customer();
        if (dto.Id > 0)
        {
            dbmodel = _context.Customer.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new Customer();
            }
        }

        dbmodel.Id = dto.Id;
        dbmodel.CompanyName = dto.CompanyName;
        dbmodel.Office_No = dto.Office_No;
        dbmodel.Name = dto.Name;
        dbmodel.Email = dto.Email;
        dbmodel.Mobile = dto.Mobile;
        dbmodel.Address = dto.Address;
        dbmodel.City = dto.City;
        dbmodel.State = dto.State;
        dbmodel.Pincode = dto.Pincode;
        dbmodel.Password = dto.Password;
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;
        dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        dbmodel.Create_by = 1;


        if (dto.Id > 0)
        {

            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            _context.Customer.Update(dbmodel);
        }
        else
        {

            dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            dbmodel.Create_by = 1;

            _context.Customer.Add(dbmodel);

        }
        _context.SaveChanges();

        return dto;
    }

    
}

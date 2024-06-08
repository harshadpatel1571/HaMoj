using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Hamoj.Service.Services;

public class VendorService : IVendorService
{
    private readonly HamojDBContext _context;
    public VendorService(HamojDBContext context)
    {
        //Set Object Value
        _context = context;
    }

    public async Task<VendorDto> AddEditVendor(VendorDto dto)
    {
        //Genrate Table Object
        var dbmodel = new Vendor();
        if (dto.Id > 0)
        {

            //Find Specific Data From Datatabse for cheaking previous Data
            dbmodel = _context.Vendor.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new Vendor();
            }
        }

        //Assign Dto Value (Form Value) Or User Inserted Value To Table value object
        dbmodel.Name = dto.Name;
        dbmodel.Email = dto.Email;
        dbmodel.MobileNumber = dto.MobileNumber;
        dbmodel.Address = dto.Address;
        dbmodel.Password = dto.Password;
        dbmodel.Create_Date = DateTime.Now;
        dbmodel.Create_by = 1;
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;

        if (dto.Id > 0)
        {
            //Update Data
            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.Now;
            _context.Vendor.Update(dbmodel);

        }
        else
        {
            //Add Data
            dbmodel.Create_by = 1;
            dbmodel.Create_Date = DateTime.Now;
            _context.Vendor.Add(dbmodel);

        }
        dbmodel.is_Active = dto.is_Active;
        dbmodel.is_Delete = dto.is_Delete;

        //Save Database Transaction
        _context.SaveChanges();

        return dto;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var dbmodel = await _context.Vendor.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Vendor.Remove(dbmodel);
            _context.SaveChanges();
            return true;
        }

        catch (Exception ex)
        {
            return false;
        }

    }


    public async Task<VendorDto> FindDuplicate(string MobileNumber, int? id)
    {
        return await _context.Vendor.Where(x => (x.MobileNumber == MobileNumber) && x.Id != id.Value).Select(x => new VendorDto
        {
            Id = x.Id,
            Email = x.Email,
            MobileNumber = x.MobileNumber,
            Address = x.Address,
            Password = x.Password,

        })
            .FirstOrDefaultAsync();
    }


    public async Task<List<VendorDto>> GetAllAsync()
    {
        var data = await _context.Vendor.Select(a => new VendorDto
        {
            Id = a.Id,
            Name = a.Name,
            Email = a.Email,
            MobileNumber = a.MobileNumber,
            Address = a.Address,
            Password= a.Password,

        }).ToListAsync();
        return data;
    }



    public async Task<VendorDto> GetDataById(int id)
    {
        return await _context.Vendor.Where(x => x.Id == id).Select(x => new VendorDto
        {
            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            MobileNumber = x.MobileNumber,
            Address = x.Address,
            Password = x.Password,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).FirstOrDefaultAsync();
    }
}

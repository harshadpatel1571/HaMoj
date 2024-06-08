
using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class VendorUserService:IVendorUserService
{
    private readonly HamojDBContext _context;

    public VendorUserService(HamojDBContext context)
    {
        // Set Object Value 
        _context = context;
    }

    public async Task<VendorUserDto> AddEdit(VendorUserDto dto, int VendorId)
    {
        var dbmodel = new VendorUser();
        if (dto.id > 0)
        {
            // Find Specific Data From Database for Cheaking Previous Data 
            dbmodel = _context.VendorUsers.Where(x => x.id == dto.id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new VendorUser();
            }
        }
        // Assign Dto Value (Form Value) or User Inserted Value To Table Object Value
        dbmodel.id = dto.id;
        dbmodel.VendorId = VendorId;
        dbmodel.Name = dto.Name;
        dbmodel.MobileNumber = dto.MobileNumber;
        dbmodel.Username = dto.Username;
        dbmodel.Password = dto.Password;
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;
        dbmodel.Create_Date = DateTime.Now;
        dbmodel.Create_by = 1;


        if (dto.id > 0)
        {

            // Update The data 
            dbmodel.id = dto.id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.Now;

            _context.VendorUsers.Update(dbmodel);
        }
        else
        {

            // Add Data 
            dbmodel.Create_Date = DateTime.Now;
            dbmodel.Create_by = 1;

            _context.VendorUsers.Add(dbmodel);

        }
        // Save Database Transection
        _context.SaveChanges();

        return dto;
    }

    public async Task<VendorUserDto> FindDuplicate(string MobileNumber)
    {
        return await _context.Vendor.Where(x => (x.MobileNumber == MobileNumber)).Select(x => new VendorUserDto
        {
            id = x.Id,
            MobileNumber = x.MobileNumber,

        })
            .FirstOrDefaultAsync();
    }

    public async Task<List<VendorUserDto>> GetAllAsync(int vendorId)
    {
        var data = await _context.VendorUsers.Where(x=>x.VendorId== vendorId).Select(x => new VendorUserDto
        {
            id = x.id,
            vendorDto = new VendorDto
            {
                Name = x.vendor.Name,
            },
            Name = x.Name,
            MobileNumber = x.MobileNumber,
            Username = x.Username,
            Password = x.Password,
        }).ToListAsync();
        return data;

    }

    public async Task<VendorUserDto> GetDataById(int id)
    {
        return await _context.VendorUsers.Where(x => x.id == id).Select(x => new VendorUserDto
        {
            id = x.id ,
            VendorId = x.VendorId,
            Name = x.Name,
            MobileNumber = x.MobileNumber,
            Username = x.Username ,
            Password = x.Password,

        }).FirstOrDefaultAsync();
    }
}

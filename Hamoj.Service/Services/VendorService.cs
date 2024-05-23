using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class VendorService : IVendorService
{
    private readonly HamojDBContext _context;
    public VendorService(HamojDBContext context)
    {
        _context = context;
    }

    public async Task<List<VendorDto>> GetAllAsync()
    {
        var data = await _context.Vendor.Select(a=>new VendorDto
        {
            Id = a.Id,
            Name = a.Name,
            Email = a.Email,
            Phone = a.Phone,
            Contact_Phone = a.Contact_Phone,
            Address = a.Address,

        }).ToListAsync();
        return data;
    }
}

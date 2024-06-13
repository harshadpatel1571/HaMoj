using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class DropDownBindService : IDropDownBindService
{
    private readonly HamojDBContext _context;
    public DropDownBindService(HamojDBContext context)
    {
        _context = context;

    }

    public async Task<List<DropDownDto>>BindCategoryDropDown()
    {
        var data = await _context.Category.Select(x => new DropDownDto
        {
            Id = x.Id,
            Name = x.Name,
        }).ToListAsync();
        return data;
    }

    async Task<List<DropDownDto>> IDropDownBindService.BindVendorUserDropDown(int VendorId)
    {
        var data = await _context.VendorUsers.Where(x=>x.VendorId== VendorId).Select(x => new DropDownDto
        {
            Id = x.id,
            Name = x.Name,
        }).ToListAsync();
        return data;

    }

    public async Task<List<DropDownDto>> BindCustomerDropDown() 
    {

        var data = await _context.Customer.Select(x => new DropDownDto
        {
            Id = x.Id,
            Name = x.Name + "( office No: " + x.Office_No + ")",
        }).ToListAsync();
        return data;
    }
}

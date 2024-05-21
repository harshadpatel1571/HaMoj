using Hamoj.DB.Context;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class CatagoryService : ICatagoryService
{
    private readonly HamojDBContext _context;
    public CatagoryService(HamojDBContext context)
    {
        _context = context;
    }

    public async Task<List<CatrgoryDto>> GetAllAsync()
    {
        var data = await _context.Category.Select(x=> new CatrgoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Image = x.Image,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).ToListAsync();

        return data;
    }
}

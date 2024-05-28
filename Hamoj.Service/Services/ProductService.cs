

using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Hamoj.Service.Services;

public class ProductService : IProductService
{
    private readonly HamojDBContext _context ;
     
        public ProductService( HamojDBContext context )
    {
        _context = context;
    }

    public async Task<ProductDto> AddEditProduct(ProductDto dto)
    {
        var dbmodel = new Product();
        if (dto.Id > 0)
        {
            dbmodel = _context.Product.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new Product();
            }
        }

        dbmodel.Id = dto.Id;
        dbmodel.Category = dto.Category;
        dbmodel.Name = dto.Name;
        dbmodel.Price = dto.Price;
        dbmodel.Description = dto.Description;
        dbmodel.is_Active = dto.is_Active;
        dbmodel.is_Delete = dto.is_Delete;
        dbmodel.Create_Date = DateTime.Now;
        dbmodel.Create_by = 1;


        if (dto.Id > 0)
        {

            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.Now;

            _context.Product.Update(dbmodel);
        }
        else
        {

            dbmodel.Create_Date = DateTime.Now;
            dbmodel.Create_by = 1;

            _context.Product.Add(dbmodel);

        }
        _context.SaveChanges();

        return dto;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var data = await _context.Product.Select(x => new ProductDto
        {
            Id = x.Id,
            Category = x.Category,
            Name = x.Name,
            Price = x.Price,
            Description = x.Description,
            Image = x.Image,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).ToListAsync();

        return data;
    }
}

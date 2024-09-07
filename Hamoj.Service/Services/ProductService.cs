

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
        dbmodel.CategoryId = dto.CategoryId;
        dbmodel.Name = dto.Name;
        dbmodel.Price = dto.Price;
        if (dto.Image != null)
        {
            dbmodel.Image = dto.Image;
        }
        dbmodel.Description = dto.Description;
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;
        dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
        dbmodel.Create_by = 1;


        if (dto.Id > 0)
        {

            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);

            _context.Product.Update(dbmodel);
        }
        else
        {

            dbmodel.Create_Date = DateTime.UtcNow.AddHours(5).AddMinutes(30);
            dbmodel.Create_by = 1;

            _context.Product.Add(dbmodel);

        }
        _context.SaveChanges();

        return dto;
    }

    public async Task<bool> DeleteProduct(int id)
    {
       try
        {
            var dbmodel = await _context.Product.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Product.Remove(dbmodel);
            _context.SaveChanges();
            return true;
        }
         
        catch(Exception ex)
        {
            return false;
        }
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var data = await _context.Product.Select(x => new ProductDto
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price,
            Description = x.Description,
            Image = x.Image,
            //CategoryDto = new CategoryDto
            //{
            //    Id = x.Category.Id,
            //    Name = x.Category.Name,
            //    Image = x.Category.Image,
            //},
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).ToListAsync();

        return data;
    }

    public async Task<ProductDto> GetDataById(int id)
    {
        return await _context.Product.Where(x => x.Id == id).Select(x => new ProductDto
        {
            Id = x.Id,
            CategoryId = x.CategoryId,
            Name = x.Name,
            Price = x.Price,
            Description = x.Description,
            Image = x.Image,
            is_Active = x.is_Active, 
            is_Delete = x.is_Delete,

        }).FirstOrDefaultAsync();
    }
}

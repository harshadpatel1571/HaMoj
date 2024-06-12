﻿using Hamoj.DB.Context;
using Hamoj.DB.Datamodel;
using Hamoj.Service.Dto;
using Hamoj.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace Hamoj.Service.Services;

public class CatagoryService : ICatagoryService
{
    private readonly HamojDBContext _context;

    public CatagoryService(HamojDBContext context)
    {
        // Set Object Value 
        _context = context;
    }

    public async Task<CategoryDto> AddEdit(CategoryDto dto)
    {
        // Generate Table Object 
        var dbmodel = new Category();
        if (dto.Id > 0)
        {
            // Find Specific Data From Database for Cheaking Previous Data 
            dbmodel = _context.Category.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (dbmodel == null)
            {
                dbmodel = new Category();
            }
        }
        // Assign Dto Value (Form Value) or User Inserted Value To Table Object Value
        dbmodel.Name = dto.Name;
        if (dto.Image != null)
        {
            dbmodel.Image = dto.Image;
        }
        dbmodel.is_Active = true;
        dbmodel.is_Delete = false;
        dbmodel.Create_Date = DateTime.Now;
        dbmodel.Create_by = 1;


        if (dto.Id > 0)
        {

            // Update The data 
            dbmodel.Id = dto.Id;
            dbmodel.Modified_by = 1;
            dbmodel.Modified_Date = DateTime.Now;

            _context.Category.Update(dbmodel);
        }
        else
        {

            // Add Data 
            dbmodel.Create_Date = DateTime.Now;
            dbmodel.Create_by = 1;

            _context.Category.Add(dbmodel);

        }
        // Save Database Transection
        _context.SaveChanges();

        return dto;
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var dbmodel = await _context.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Category.Remove(dbmodel);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<CategoryDto> FindDuplicate(string name, int? id)
    {
        return await _context.Category.Where(x => x.Name == name &&  x.Id != id.Value).Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Image = x.Image,
            })
            .FirstOrDefaultAsync();
    }


    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var data = await _context.Category.Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Image = x.Image,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete,
        }).ToListAsync();
        return data;
    }

    public async Task<CategoryDto> GetDataById(int id)
    {
        return await _context.Category.Where(x => x.Id == id).Select(x => new CategoryDto
        {
            Id = x.Id,
            Name = x.Name,
            Image = x.Image,
            is_Active = x.is_Active,
            is_Delete = x.is_Delete

        }).FirstOrDefaultAsync();
    }
}

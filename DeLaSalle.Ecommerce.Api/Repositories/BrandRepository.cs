using DeLaSalle.Ecommerce.Api.DataAccess.Interfaces;
using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using DeLaSalle.Ecommerce.Core.Dto;

namespace DeLaSalle.Ecommerce.Api.Repositories;

public class BrandRepository : IBrandRepository
{

    
    private readonly IDbContext _dbContext;
    
    public BrandRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Brand> SaveAsync(Brand brand)
    {
        brand.Id = await _dbContext.Connection.InsertAsync(brand);
        return brand;
    }

    public async Task<Brand> UpdateAsync(Brand brand)
    {
        await _dbContext.Connection.UpdateAsync(brand);
        return brand;
    }

    public async Task<List<Brand>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Brand WHERE IsDeleted = 0";
        var brands = await _dbContext.Connection.QueryAsync<Brand>(sql);
        return brands.ToList();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var brand = await GetById(id);
        
        if (brand == null)
            return false;

        brand.IsDeleted = true;
        return await _dbContext.Connection.UpdateAsync(brand);
    }

    public async Task<Brand> GetById(int id)
    {
        var brand = await _dbContext.Connection.GetAsync<Brand>(id);

        if (brand == null)
            return null;

        return brand.IsDeleted ? null : brand;
    }
}
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Repositories.Interfaces;

public interface IBrandRepository
{
    Task<Brand> SaveAsync(Brand brand);
    Task<Brand> UpdateAsync(Brand brand);
    Task<List<Brand>> GetAllAsync();
    Task<bool> DeleteAsync(int id);
    Task<Brand> GetById(int id);
}
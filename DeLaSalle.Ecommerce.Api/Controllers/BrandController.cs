using DeLaSalle.Ecommerce.Api.Repositories.Interfaces;
using DeLaSalle.Ecommerce.Core.Dto;
using DeLaSalle.Ecommerce.Core.Entities;
using DeLaSalle.Ecommerce.Core.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeLaSalle.Ecommerce.Api.Controllers;

[ApiController]
[Route("api/[Controller]")]

public class BrandController : ControllerBase
{

    private IBrandRepository _repository;

    public BrandController(IBrandRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<ActionResult<Response<List<Brand>>>> GetAll()
    {
        var response = new Response<List<Brand>>();
        var brands = await _repository.GetAllAsync();
        response.Data = brands;
        return Ok(response);
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Brand>>> GetById(int id)
    {
        var response = new Response<Brand>();
        var brand = await _repository.GetById(id);
        response.Data = brand;

        if (brand == null)
        {
            response.Errors.Add("Brand Not Found");
            return NotFound(response);
        }
        
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<Response<Brand>>> Post([FromBody] Brand brand)
    {
        brand = await _repository.SaveAsync(brand);
        
        var response = new Response<Brand>();
        response.Data = brand;

        return Created($"api/brand/{brand.Id}", response);
    }
    
    [HttpPut]
    public async Task<ActionResult<Response<Brand>>> Put([FromBody] Brand brand)
    {
        var result = await _repository.UpdateAsync(brand);
        
        var response = new Response<Brand>{Data = result}; 
        return Ok( response);
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ActionResult<Response<Brand>>> Delete(int id)
    {
        var response = new Response<bool>();
        var result = await _repository.DeleteAsync(id);
        response.Data = result;

        return Ok(response);

    }

}
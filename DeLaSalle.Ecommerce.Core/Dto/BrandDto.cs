using DeLaSalle.Ecommerce.Core.Entities;

namespace DeLaSalle.Ecommerce.Core.Dto;

public class BrandDto : DtoBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public BrandDto()
    {
        
    }

    public BrandDto(Brand brand)
    {
        Id = brand.Id;
        Name = brand.Name;
        Description = brand.Description;
    }
}
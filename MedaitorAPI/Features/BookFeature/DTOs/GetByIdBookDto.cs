using System;
namespace MedaitorAPI.Features.BookFeature.DTOs;

public class GetByIdBookDto
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }
}


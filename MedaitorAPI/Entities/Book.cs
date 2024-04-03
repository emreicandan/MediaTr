using System;
using MedaitorAPI.Core.Repository;

namespace MedaitorAPI.Entities;

public class Book:Entity<int>
{
    public string Name { get; set; }

    public string Description { get; set; }

    public string Author { get; set; }
}


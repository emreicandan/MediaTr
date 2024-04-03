using System;
using MedaitorAPI.Core.Repository;

namespace MedaitorAPI.Entities;

public class User:Entity<int>
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
}


using System;
namespace MedaitorAPI.Core.Repository;

public class Entity
{

}

public class Entity<PKey>:Entity
{
    public PKey Id { get; set; }
}



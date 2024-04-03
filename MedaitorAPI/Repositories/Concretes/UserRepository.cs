using System;
using MedaitorAPI.Core.Repository;
using MedaitorAPI.Entities;
using MedaitorAPI.Repositories.Abstract;
using MedaitorAPI.Repositories.Context;


namespace MedaitorAPI.Repositories.Concretes;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AdvencedDbContext context) : base(context)
    {
    }
}


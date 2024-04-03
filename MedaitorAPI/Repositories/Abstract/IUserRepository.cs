using System;
using MedaitorAPI.Core.Repository;
using MedaitorAPI.Entities;

namespace MedaitorAPI.Repositories.Abstract;

public interface IUserRepository:IRepository<User>,IAsyncRepository<User>
{
}


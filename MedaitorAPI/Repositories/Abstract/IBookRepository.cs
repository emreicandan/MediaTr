using System;
using MedaitorAPI.Core.Repository;
using MedaitorAPI.Entities;

namespace MedaitorAPI.Repositories.Abstract;

public interface IBookRepository:IRepository<Book>,IAsyncRepository<Book>
{
}


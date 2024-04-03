using System;
using MedaitorAPI.Core.Repository;
using MedaitorAPI.Entities;
using MedaitorAPI.Repositories.Abstract;
using MedaitorAPI.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace MedaitorAPI.Repositories.Concretes;

public class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(AdvencedDbContext context) : base(context)
    {
    }
}


using System;
using MedaitorAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedaitorAPI.Repositories.Context;

public class AdvencedDbContext:DbContext
{
    private IConfiguration Configuration { get; set; }

    public AdvencedDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Dev"));
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
}


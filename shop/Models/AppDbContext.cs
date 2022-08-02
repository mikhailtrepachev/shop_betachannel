using System;
using Microsoft.EntityFrameworkCore;
using shop.Models.DatabaseObjects;

namespace shop.Models;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<CarDo> Cars { get; set; }

    public DbSet<UserDo> Users { get; set; }
}


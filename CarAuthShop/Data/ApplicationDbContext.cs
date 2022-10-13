using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MudBlazor;


namespace CarAuthShop.Data;

public class ApplicationDbContext : IdentityDbContext<UserDo>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<CarDo> Cars { get; set; } = null!;

    public DbSet<CarUserDo> CarUser { get; set; } = null!;

    public DbSet<CarImagesDo> CarImages { get; set; } = null!;

    public DbSet<UserDo> UserDo { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        

        //osetreni modelu
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        
        
        base.OnModelCreating(modelBuilder);
    }
}

public class CarConfiguration : IEntityTypeConfiguration<CarDo>
{
    public void Configure(EntityTypeBuilder<CarDo> builder)
    {
        builder
            .Property(c => c.Label)
            .HasMaxLength(50);
        builder
            .Property(c => c.Model)
            .HasMaxLength(50);
    }
}


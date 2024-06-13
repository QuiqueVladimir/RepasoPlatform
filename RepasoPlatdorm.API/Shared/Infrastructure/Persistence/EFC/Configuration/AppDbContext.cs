using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using RepasoPlatdorm.API.Todo.Domain.Model.Entities;
using RepasoPlatdorm.API.Todo.Domain.Model.ValueObjects;

namespace RepasoPlatdorm.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        //Aqui se agrega cosas
        builder.Entity<Plan>().HasKey(c => c.Id);
        builder.Entity<Plan>().Property(c => c.Id).ValueGeneratedOnAdd();
        
        builder.Entity<Plan>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Plan>().Property(c => c.MaxUsers).IsRequired();
        builder.Entity<Plan>().Property(c => c.IsDefault).IsRequired();
        
        builder.Entity<Plan>()
            .Property(e=>e.Name)
            .HasConversion(
                v=>v.Name,
                v=>new PlanName(v))
                    .HasMaxLength(100)
                    .IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}
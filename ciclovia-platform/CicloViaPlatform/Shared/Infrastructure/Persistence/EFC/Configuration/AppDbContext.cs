
using CicloViaPlatform.Routes;
using CicloViaPlatform.Routes.Domain.Model.Aggregate;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace CicloViaPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<RouteDistance>().HasKey(r => r.Id);

        builder.Entity<RouteDistance>().Property(r => r.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Entity<RouteDistance>().Property(r => r.RoutesApiKey)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<RouteDistance>().Property(r => r.Origin)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<RouteDistance>().Property(r => r.Destination)
            .IsRequired()
            .HasMaxLength(100);

        builder.Entity<RouteDistance>().Property(r => r.DistanceKm)
            .IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
    
}
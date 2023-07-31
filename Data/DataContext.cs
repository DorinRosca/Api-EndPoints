using ApiEndPoints.Features.Brands.Entities;
using ApiEndPoints.Features.Cars.Entities;
using ApiEndPoints.Features.Drives.Entities;
using ApiEndPoints.Features.FuelTypes.Entities;
using ApiEndPoints.Features.Orders.Entities;
using ApiEndPoints.Features.Statuses.Entities;
using ApiEndPoints.Features.Transmissions.Entities;
using ApiEndPoints.Features.Vehicles.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ApiEndPoints.Data
{
    public class DataContext : DbContext
     {
          public DataContext(DbContextOptions options) : base(options)
          {
          }
          public virtual DbSet<Brand> Brand { get; set; }
          public virtual DbSet<Car> Car { get; set; }
          public virtual DbSet<Drive> Drive { get; set; }
          public virtual DbSet<FuelType> FuelType { get; set; }
          public virtual DbSet<Order> Order { get; set; }
          public virtual DbSet<Status> Status { get; set; }
          public virtual DbSet<Transmission> Transmission { get; set; }
          public virtual DbSet<Vehicle> Vehicle { get; set; }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {

               base.OnModelCreating(modelBuilder);
          }
     }
}

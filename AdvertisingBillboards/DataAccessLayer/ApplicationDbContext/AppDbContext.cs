using AdvertisingBillboards.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvertisingBillboards.DataAccessLayer.ApplicationDbContext;

public sealed class AppDbContext : DbContext
{
    public DbSet<Advertisement> Advertisements { get; set; }
    
    public DbSet<AdvertisementStatistics> AdvertisementStatistics { get; set; }
    
    public DbSet<Device> Devices { get; set; }
    
    public DbSet<DeviceGroup> DeviceGroups { get; set; }
    
    public DbSet<User> Users { get; set; }
    
    public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasMany(u => u.DeviceGroups).WithOne(d => d.User);
        modelBuilder.Entity<User>().HasMany(u => u.Devices).WithOne(d => d.User);
        modelBuilder.Entity<DeviceGroup>().HasMany(d => d.Devices).WithOne(u => u.DeviceGroup);
        base.OnModelCreating(modelBuilder);
    }
}
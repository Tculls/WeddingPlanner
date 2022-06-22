#pragma warning disable CS8618

using Microsoft.EntityFrameworkCore;
namespace WeddingPlanner.Models;
public class ORMContext : DbContext
{
    public ORMContext(DbContextOptions options) : base(options){  }

    public DbSet<Wedding> Weddings {get; set; }
    public DbSet<User> Users {get; set; }
}
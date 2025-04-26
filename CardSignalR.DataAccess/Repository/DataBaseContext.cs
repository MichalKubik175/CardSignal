using CardSignalR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<CardLink> CardLinks { get; set; }
}
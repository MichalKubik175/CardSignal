using CardSignalR.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardSignalR.DataAccess.Repository;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<CardLink> CardLinks { get; set; }
}
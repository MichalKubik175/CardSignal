using CardSignal.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardSignal.DataAccess.Repository;

public class DataBaseContext : DbContext
{
    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<CardLink> CardLinks { get; set; }
    public DbSet<Card> Cards { get; set; }
}
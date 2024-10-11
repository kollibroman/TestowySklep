using Microsoft.EntityFrameworkCore;
using TestowySklep.Api.Persitence.Models;

namespace TestowySklep.Api.Persitence;

public class TestowyDbContext : DbContext
{
    public TestowyDbContext()
    {
        
    }
    
    public TestowyDbContext(DbContextOptions<TestowyDbContext> options) : base(options)
    {
        
    }

    public virtual DbSet<User> Users => Set<User>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=TestowySklep.db");
    }
}
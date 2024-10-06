using Microsoft.EntityFrameworkCore;

namespace TestowySklep.Api.Persitence;

public class TestowyDbContext : DbContext
{
    public TestowyDbContext()
    {
        
    }
    
    public TestowyDbContext(DbContextOptions<TestowyDbContext> options) : base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Kalkulator.db");
    }
}
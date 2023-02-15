using Microsoft.EntityFrameworkCore;
using TestTask.Shared.Entities;

namespace TestTask.WebAPI;

public class DBContext : DbContext
{
    public DbSet<OrderEntity> Orders => Set<OrderEntity>();
    
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
}
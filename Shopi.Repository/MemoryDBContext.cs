using Microsoft.EntityFrameworkCore;
using Shopi.Repository.Entity;


namespace Shopi.Repository
{
    public class MemoryDBContext : DbContext
    {
        public MemoryDBContext(DbContextOptions<MemoryDBContext> options)
        : base(options) { }

        public DbSet<OrderEntity> Order { get; set; }
    }
}

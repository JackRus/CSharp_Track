using Microsoft.EntityFrameworkCore;
using GlobalEvent.Models.VisitorViewModels;

namespace GlobalEvent.Data
{
    public class VisitorDbContext: DbContext
    {
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<Order> Orders { get; set; }
        public VisitorDbContext(DbContextOptions options) : base(options) { }
    }
}
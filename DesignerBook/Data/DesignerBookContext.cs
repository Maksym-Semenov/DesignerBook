using DesignerBook.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignerBook.Data
{
    public class DesignerBookContext : DbContext
    {
        public DesignerBookContext(DbContextOptions<DesignerBookContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<TPerson> Persons { get; set; }
        public DbSet<TEvent> Events { get; set; }
    }
}

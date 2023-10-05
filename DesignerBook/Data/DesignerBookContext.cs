using DesignerBook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using DesignerBook.ViewModels;

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
        public DbSet<DesignerBook.ViewModels.PersonsWithEvents> PersonsWithEvents { get; set; } = default!;
    }
}

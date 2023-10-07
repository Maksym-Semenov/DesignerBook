using DesignerBook.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.ViewModels
{
    public class PersonsWithEvents
    {
        public int Id { get; set; }
        public IQueryable<TEvent>? FromEvents { get; set; }
        public IQueryable<TPerson>? FromPersons { get; set; }
    }
}

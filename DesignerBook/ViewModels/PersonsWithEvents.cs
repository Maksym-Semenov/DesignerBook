using DesignerBook.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.ViewModels
{
    public class PersonsWithEvents
    {
        public Guid Id { get; set; }
        public IEnumerable<TEvent>? EventsList { get; set; }
        public IEnumerable<TPerson>? PersonsList { get; set; }
    }
}

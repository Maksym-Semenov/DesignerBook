using DesignerBook.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.ViewModels
{
    public class EventWithPerson
    {
        
        public TEvent Event { get; set; }
        public TPerson Person { get; set; }
    }
}

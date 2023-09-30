using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DesignerBook.Models
{
    public class TEvent
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        [Display(Name = "Кількість подій")]
        public int? Count { get; set; }

        [Display(Name = "Номер події"),]
        public int EventSerialNumber { get; set; }

        [Display(Name = "Дата створення")] 
        public DateTime EventDateRegister { get; set; } = DateTime.Now;

        [Display(Name = "Наступна дата для зв'язку")]
        public DateTime NextDateCommunication { get; set; }

        [Display(Name = "Комментарій")]
        public string Comment { get; set; } = string.Empty;
    }
}

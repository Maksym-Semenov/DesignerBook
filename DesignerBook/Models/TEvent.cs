using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.Models
{
    public class TEvent
    {
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        [Display(Name = "Номер події")]
        public uint EventSerialNumber { get; set; }

        [Display(Name = "Дата створення")]
        public DateTime EventDateRegister { get; set; }

        [Display(Name = "Наступна дата для зв'язку")]
        public DateTime NextDateCommunication { get; set; }

        [Display(Name = "Комментарій")]
        public string Comment { get; set; } = string.Empty;
    }
}

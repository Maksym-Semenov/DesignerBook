using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DesignerBook.Models
{
    public class TEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(TPerson)), Display(Name = "Особа")]
        public Guid PersonId { get; set; }

        [Display(Name = "Кількість подій")]
        public int? Count { get; set; }

        [Display(Name = "Дата створення")] 
        public DateTime? EventDateRegister { get; set; }

        [Display(Name = "Наступна дата для зв'язку")]
        public DateTime NextDateCommunication { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Коментар")]
        public string Comment { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.Models
{
    /// <summary>
    /// Події
    /// </summary>
    [Table("Events"), Display(Name = "Події")]
    public class TEvent
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Display(Name = "Номер події")]
        public uint EventSerialNumber { get; set; }

        [Display(Name = "Дата створення події")]
        public DateTime EventDateRegister { get; set; }

        [Required, Display(Name = "Наступна дата зв'язку")]
        public DateTime NextDateCommunication { get; set; }

        [Required, Display(Name = "Комментарій")]
        public string Comment { get; set; } = string.Empty;
    }
}

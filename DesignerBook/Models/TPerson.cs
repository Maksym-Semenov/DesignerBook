using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.Models
{
    [Table("Persons"), Display(Name = "Дизайнери, архітектори, виконроби")]
    public class TPerson /*: IdentityUser*/
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [StringLength(50), Display(Name = "Прізвище")]
        public string FirstName { get; set; } = string.Empty;

        [Required, StringLength(50), Display(Name = "Ім'я")]
        public string MiddleName { get; set; } = string.Empty;

        [StringLength(50), Display(Name = "По-батькові")]
        public string LastName { get; set; } = string.Empty;

        private string _middleName => string.IsNullOrEmpty(MiddleName) ? string.Empty : MiddleName[..1];
        private string _lastName => string.IsNullOrEmpty(LastName) ? string.Empty : LastName[..1];

        [Display(Name = "ПІБ")]
        public string PIB => string.IsNullOrEmpty(MiddleName + LastName)
                                    ? FirstName
                                    : $"{FirstName} {_middleName}.{_lastName}";

        [Display(Name = "Події")]
        public virtual IEnumerable<TEvent>? Events { get; set; }
    }
}

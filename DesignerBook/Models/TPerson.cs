using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.Models
{
    public class TPerson /*: IdentityUser*/
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Display(Name="Кількість подій")]
        public int? EventsCount { get; set; }

        [Required, Display(Name = "Ім'я")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; } = string.Empty;

        [Display(Name = "Прізвище")]
        public string LastName { get; set; } = string.Empty;

        private string _middleName => string.IsNullOrEmpty(MiddleName) ? string.Empty : MiddleName[..1];
        private string _firstName => string.IsNullOrEmpty(FirstName) ? string.Empty : FirstName[..1];

        public string PIB => string.IsNullOrEmpty(MiddleName + LastName)
            ? FirstName
            : $"{LastName} {_firstName}.{_middleName}.";

        public virtual IEnumerable<TEvent>? Events { get; set; }
    }
}

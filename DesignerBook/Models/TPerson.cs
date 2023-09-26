using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.Models
{
    public class TPerson /*: IdentityUser*/
    {
        public Guid Id { get; set; }

        [Required, Display(Name = "Ім'я")]
        public string FirstName { get; set; } = string.Empty;

        [Display(Name = "По-батькові")]
        public string MiddleName { get; set; } = string.Empty;

        [Display(Name = "Прізвище")]
        public string LastName { get; set; } = string.Empty;

        private string _middleName => string.IsNullOrEmpty(MiddleName) ? string.Empty : MiddleName[..1];
        private string _lastName => string.IsNullOrEmpty(LastName) ? string.Empty : LastName[..1];

        public string PIB => string.IsNullOrEmpty(MiddleName + LastName)
                                    ? FirstName
                                    : $"{FirstName} {_middleName}.{_lastName}";

        public virtual IEnumerable<TEvent>? Events { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DesignerBook.Models
{
    public class TEvent
    {
        public Guid Id { get; set; }

        public uint EventSerialNumber { get; set; }

        public DateTime EventDateRegister { get; set; }

        public DateTime NextDateCommunication { get; set; }

        public string Comment { get; set; } = string.Empty;
    }
}

using DesignerBook.Models;

namespace DesignerBook.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<TPerson> Persons { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}

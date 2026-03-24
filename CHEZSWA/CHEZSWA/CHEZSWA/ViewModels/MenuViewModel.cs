using CHEZSWA.Models;   
namespace CHEZSWA.ViewModels

{
    public class MenuViewModel
    {
        public Menu SelectedMenu { get; set; }
        public IEnumerable<Menu> AllMenus { get; set; }
    }
}

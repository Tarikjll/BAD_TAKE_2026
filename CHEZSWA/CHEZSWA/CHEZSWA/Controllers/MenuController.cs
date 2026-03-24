using CHEZSWA.Models;
using Microsoft.AspNetCore.Mvc;
using CHEZSWA.ViewModels;   

namespace CHEZSWA.Controllers
{
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;

        public readonly MenuRepository _menuRepository;
        public MenuController(ILogger<MenuController> logger, MenuRepository menuRepository)
        {
            _logger = logger;
            _menuRepository = menuRepository;
        }

        [HttpGet]
        public IActionResult Menu(string id )
        {
            Menu selectedMenu = _menuRepository.GetById(id);
            if (selectedMenu == null)
            {
                _logger.LogWarning("Menu met id {MenuId} niet gevonden", id);
                return NotFound();
            }
            IEnumerable<Menu> allMenus = _menuRepository.GetAll();
            MenuViewModel menuViewModel = new MenuViewModel
            {
                SelectedMenu = selectedMenu,
                AllMenus = allMenus
            };
            return View(menuViewModel);





        }
    }
}

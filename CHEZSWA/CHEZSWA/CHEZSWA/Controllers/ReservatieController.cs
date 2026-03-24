using Microsoft.AspNetCore.Mvc;

namespace CHEZSWA.Controllers
{
    public class ReservatieController : Controller
    {
        [HttpGet]
        public IActionResult Reservatie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            return View(userModel);
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}

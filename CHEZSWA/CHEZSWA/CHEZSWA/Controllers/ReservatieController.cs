using CHEZSWA.Models;
using CHEZSWA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CHEZSWA.Controllers
{
    public class ReservatieController : Controller
    {
        [HttpGet]
        public IActionResult Reservatie()
        {
            return View(new FormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(FormViewModel usermodel)
        {
            if (!ModelState.IsValid)
            {
                usermodel.Akkoord = false; 
                return View(usermodel);    
            }
            TempData["Voornaam"] = usermodel.Voornaam; // voorbeeld: data doorgeven naar bevestiging
            return RedirectToAction("Bevestiging");
            
        }
        public IActionResult Bevestiging()
        {
            return View();
        }
    }
}

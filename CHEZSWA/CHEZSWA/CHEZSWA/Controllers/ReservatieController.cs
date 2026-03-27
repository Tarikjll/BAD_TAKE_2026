using CHEZSWA.Models;
using CHEZSWA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CHEZSWA.Models.Repositories;  

namespace CHEZSWA.Controllers
{
    public class ReservatieController : Controller
    {

     

        private readonly ReservatieRepository _reservatieRepository;       
        
        public ReservatieController(ReservatieRepository reservatieRepository)
        {
            _reservatieRepository = reservatieRepository;
        }   

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
                return View("Reservatie", usermodel);  
            }

            Reservatie nieweReservatie = new Reservatie
            {
                Voornaam = usermodel.Voornaam,
                Familienaam = usermodel.Familienaam,
                Datum = usermodel.Datum,
                AantalPersonen = usermodel.AantalPersonen,
                Tijdstip = usermodel.Tijdstip
            };

            _reservatieRepository.AddReservatie(nieweReservatie);
            TempData["Voornaam"] = usermodel.Voornaam; 
            
            return RedirectToAction("ReservatieBevestiging");
            
        }
        public IActionResult ReservatieBevestiging()
        {
            return View();

           
        }

        public IActionResult Overzicht()
        {
            List<Reservatie> reservaties = _reservatieRepository.GetAllReservaties();
            return View(reservaties);
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Verwijderen(int id)
        {
            _reservatieRepository.RemoveReservatie(id);
            return RedirectToAction("Overzicht");
        }

        public IActionResult Details(int id)
        {
            Reservatie reservatie = _reservatieRepository.GetReservatieById(id);

            if (reservatie == null)
            {
                return NotFound(); 
            }
            return View(reservatie);


        }
    }
}

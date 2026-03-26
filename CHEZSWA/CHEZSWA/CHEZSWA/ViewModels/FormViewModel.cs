using CHEZSWA.ViewModels.CustomValidators;
using System.ComponentModel.DataAnnotations;
using static CHEZSWA.ViewModels.CustomValidators.ExpectedValue;
using static CHEZSWA.ViewModels.CustomValidators.FutureDate;

namespace CHEZSWA.ViewModels
{
   
    public class FormViewModel
    {
        [Required(ErrorMessage = "Voornaam is verplicht.")]
        [Display(Name = "Voornaam")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Familienaam is verplicht.")]
        [Display(Name = "Familienaam")]
        public string Familienaam { get; set; }


        [Required(ErrorMessage = "Email-adres is verplicht.")]
        [EmailAddress(ErrorMessage = "Email-adres is ongeldig.")]
        [Display(Name = "Email-adres")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Bevestiging email-adres is verplicht.")]
        [EmailAddress(ErrorMessage = "Bevestiging email-adres is ongeldig.")]
        [Compare("Email", ErrorMessage = "Email-adres komt niet overeen.")]
        [Display(Name = "Bevestiging email-adres")]
        public string BevestigingEmail { get; set; }


        [Required(ErrorMessage = "Datum van reservatie is verplicht.")]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Datum kan niet in het verleden liggen")]

        [Display(Name = "Datum van reservatie")]
        public DateTime Datum { get; set; }

        [Required]
        [Display(Name = "Akkoord met algemene voorwaarden")]
        [ExpectedValue(true, ErrorMessage = "Je moet akkoord gaan met de algemene voorwaarden.")]
        public bool Akkoord { get; set; }

        [Required(ErrorMessage = "Aantal personen is verplicht.")]
        [Range(1, 10, ErrorMessage = "Aantal personen moet tussen 1 en 10 liggen.")]
        [Display(Name = "Aantal personen")]
        public int AantalPersonen { get; set; }

        [Required(ErrorMessage = "Kies een tijdstip.")]
        [Display(Name = "Tijdstip")]
        public Tijdstip Tijdstip { get; set; }

        public FormViewModel()
        {
            Datum = DateTime.Today;
        }
    }
}

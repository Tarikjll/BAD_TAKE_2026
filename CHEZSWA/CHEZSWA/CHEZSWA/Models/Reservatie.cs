using  CHEZSWA.ViewModels;

namespace CHEZSWA.Models
{
    public class Reservatie
    {
        public int Id { get; set; } 
        public string Voornaam { get; set; }
           
        public string Familienaam { get; set; }
        public string Email { get; set; }
        public DateTime Datum { get; set; }
        public int AantalPersonen { get; set; }
        public Tijdstip Tijdstip { get; set; }

    }
}

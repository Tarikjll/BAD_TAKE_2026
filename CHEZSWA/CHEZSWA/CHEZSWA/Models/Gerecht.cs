namespace CHEZSWA.Models
{

    public class Gerecht
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        public bool IsVeggie { get; set; }

        public string MenuId { get; set; }
        public Menu Menu { get; set; }

    }

}

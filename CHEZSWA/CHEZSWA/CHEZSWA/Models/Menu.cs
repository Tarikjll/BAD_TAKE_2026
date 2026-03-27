using System.ComponentModel.DataAnnotations;

namespace CHEZSWA.Models
{
    public class Menu
    {
        [Key]
        public string Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Gerecht> Gerechten { get; set; }


    }

}

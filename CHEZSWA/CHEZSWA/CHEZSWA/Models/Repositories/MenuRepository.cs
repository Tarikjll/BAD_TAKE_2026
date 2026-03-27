using Microsoft.EntityFrameworkCore;

namespace CHEZSWA.Models.Repositories
{

    public class MenuRepository
    {
       private readonly ChezSwaDbContext _context;

        public MenuRepository(ChezSwaDbContext context)
        {
           _context = context;
        }

     
        public IEnumerable<Menu> GetAll()
        {
            return _context.Menus.ToList();
        }

        public Menu GetById(string id)
        {
            return _context.Menus
                .Include(m => m.Gerechten)  
                .FirstOrDefault(m => m.Id == id);
        }
    }

}

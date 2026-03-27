using CHEZSWA.Models;
using System.Diagnostics;
namespace CHEZSWA.Models.Repositories
{
    public class ReservatieRepository

    {   
        private readonly ChezSwaDbContext  _context;



        public ReservatieRepository(ChezSwaDbContext context)
        {
            _context = context;
        }


        public Reservatie AddReservatie(Reservatie reservatie)
        {

          
            _context.Add(reservatie);
            _context.SaveChanges();
            return reservatie;
            
        }

        public Reservatie GetReservatieById(int id)
        {
          Reservatie reservatie =  _context.Reservaties.FirstOrDefault(r => r.Id == id);
           
           
            return reservatie;



                        }
        public void RemoveReservatie(int id)
        {
            Reservatie reservatie = _context.Reservaties.FirstOrDefault(r => r.Id == id);
            if (reservatie != null)
            {
                _context.Remove(reservatie);
            }
            _context.SaveChanges();

        }

        public List<Reservatie> GetAllReservaties()
        {   
            List<Reservatie> reservaties = _context.Reservaties.ToList();
           
            return reservaties;
        }
    }
}

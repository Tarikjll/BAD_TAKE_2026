using CHEZSWA.Models;
using System.Diagnostics;
namespace CHEZSWA.Models.Repositories
{
    public class ReservatieRepository
    {
        private static List<Reservatie> _reservaties = new List<Reservatie>();   
        private int _nextId = 1;


        public Reservatie AddReservatie(Reservatie reservatie)
        {

            reservatie.Id = _nextId++;
            _reservaties.Add(reservatie);
            return reservatie;
        }

        public Reservatie GetReservatieById(int id)
        {
            return _reservaties.FirstOrDefault(r => r.Id == id);
        }
        public void RemoveReservatie(int id)
        {
            Reservatie reservatie = _reservaties.FirstOrDefault(r => r.Id == id);
            if (reservatie != null)
            {
                _reservaties.Remove(reservatie);
            }
        }

        public List<Reservatie> GetAllReservaties()
        {
            return _reservaties;
        }
    }
}

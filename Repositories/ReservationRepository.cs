using System.Linq;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codacious.GraphQL.Repositories
{
    public class ReservationRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public ReservationRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public IQueryable<Reservation> GetQuery()
        {
            return _hotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest);
        }


        public Reservation Add(Reservation reservation)
        {
            var added = _hotelDbContext.Reservations.Add(reservation);
            _hotelDbContext.SaveChanges();
            return added.Entity;
        }

        public Reservation Remove(int id)
        {
            var reservation = _hotelDbContext.Reservations.SingleOrDefault(reservation => reservation.Id == id);
            _hotelDbContext.Reservations.Remove(reservation);
            _hotelDbContext.SaveChanges();
            return reservation;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Codacious.GraphQL.Repositories
{
    public class ReservationRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        private readonly MapperConfiguration _config;

        public ReservationRepository(HotelDbContext hotelDbContext, MapperConfiguration config)
        {
            _hotelDbContext = hotelDbContext;
            _config = config;
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

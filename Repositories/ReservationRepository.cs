using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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

        public async Task<List<T>> GetAll<T>()
        {
            return await _hotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ProjectTo<T>(_config)
                .ToListAsync();
        }

        public IQueryable<Reservation> GetQuery()
        {
            return _hotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest);
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            return await _hotelDbContext
                .Reservations
                .Include(x => x.Room)
                .Include(x => x.Guest)
                .ToListAsync();
        }
    }
}

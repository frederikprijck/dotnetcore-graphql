using System.Linq;
using AutoMapper;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;

namespace Codacious.GraphQL.Repositories
{
    public class GuestRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        private readonly MapperConfiguration _config;

        public GuestRepository(HotelDbContext hotelDbContext, MapperConfiguration config)
        {
            _hotelDbContext = hotelDbContext;
            _config = config;
        }


        public IQueryable<Guest> GetQuery()
        {
            return _hotelDbContext.Guests;
        }
    }
}

using System.Linq;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;

namespace Codacious.GraphQL.Repositories
{
    public class GuestRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public GuestRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }


        public IQueryable<Guest> GetQuery()
        {
            return _hotelDbContext.Guests;
        }
    }
}

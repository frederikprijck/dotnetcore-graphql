using System.Linq;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;

namespace Codacious.GraphQL.Repositories
{
    public class RoomRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public RoomRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }


        public IQueryable<Room> GetQuery()
        {
            return _hotelDbContext.Rooms;
        }
    }
}

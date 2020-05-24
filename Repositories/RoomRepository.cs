using System.Linq;
using AutoMapper;
using Codacious.GraphQL.Context;
using Codacious.GraphQL.Entities;

namespace Codacious.GraphQL.Repositories
{
    public class RoomRepository
    {
        private readonly HotelDbContext _hotelDbContext;
        private readonly MapperConfiguration _config;

        public RoomRepository(HotelDbContext hotelDbContext, MapperConfiguration config)
        {
            _hotelDbContext = hotelDbContext;
            _config = config;
        }


        public IQueryable<Room> GetQuery()
        {
            return _hotelDbContext.Rooms;
        }
    }
}

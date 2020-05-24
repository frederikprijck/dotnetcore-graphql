using System;
using AutoMapper;
using Codacious.GraphQL.Entities;
using Codacious.GraphQL.Models;

namespace Codacious.GraphQL.AutoMapper
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Guest, GuestModel>();
            CreateMap<Room, RoomModel>();
            CreateMap<Reservation, ReservationModel>();
        }
    }
}

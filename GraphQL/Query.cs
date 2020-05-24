using System.Linq;
using System.Collections.Generic;
using Codacious.GraphQL.Repositories;
using GraphQL.Types;
using Codacious.GraphQL.Entities;

namespace Codacious.GraphQL.GraphQL
{
    public class HotelQuery : ObjectGraphType
    {
        public HotelQuery(GuestRepository guestRepository, ReservationRepository reservationRepository, RoomRepository roomRepository)
        {
            Field<ListGraphType<RoomType>>("listGuests",
                resolve: context =>
                {
                    return guestRepository.GetQuery().ToList();
                }
            );

            Field<ListGraphType<ReservationType>>("listReservations",
                resolve: context =>
                {
                    return reservationRepository.GetQuery().ToList();
                }
            );

            Field<ListGraphType<RoomType>>("listRooms",
                resolve: context =>
                {
                    return roomRepository.GetQuery().ToList();
                }
            );

            Field<ListGraphType<RoomType>>("searchRooms",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "allowedSmoking"
                    },
                    new QueryArgument<BooleanGraphType>
                    {
                        Name = "available"
                    },
                }),
               resolve: context =>
               {
                   var query = roomRepository.GetQuery();
                   var allowedSmoking = context.GetArgument<bool?>("allowedSmoking");
                   var available = context.GetArgument<bool?>("available");

                   if (allowedSmoking.HasValue)
                   {
                       query = query.Where(r => r.AllowedSmoking == allowedSmoking.Value);
                   }

                   if (available.HasValue)
                   {
                       query = query.Where(r => r.Status == (available.Value ? RoomStatus.Available : RoomStatus.Unavailable));
                   }

                   return query.ToList();
               }
           );

            Field<RoomType>("getRoom",
                arguments: new QueryArguments(new List<QueryArgument>
                {
                    new QueryArgument<IntGraphType>
                    {
                        Name = "id"
                    },
                }),
               resolve: context =>
               {
                   var query = roomRepository.GetQuery();
                   var id = context.GetArgument<int?>("id");

                   if (id.HasValue)
                   {
                       return query.SingleOrDefault(r => r.Id == id.Value);
                   }

                   return null;
               }
           );

        }
    }
}

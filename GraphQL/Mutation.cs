using Codacious.GraphQL.Repositories;
using GraphQL.Types;
using Codacious.GraphQL.Entities;

namespace Codacious.GraphQL.GraphQL
{
    public class AddReservationInputType : InputObjectGraphType
    {
        public AddReservationInputType()
        {
            Name = "AddReservationInputType";
            Field<NonNullGraphType<IntGraphType>>("roomId");
            Field<NonNullGraphType<IntGraphType>>("guestId");
            Field<NonNullGraphType<DateGraphType>>("checkinDate");
            Field<NonNullGraphType<DateGraphType>>("CheckoutDate");
        }
    }

    public class HotelMutation : ObjectGraphType
    {
        public HotelMutation(ReservationRepository reservationRepository)
        {

            Field<ReservationType>("addReservation",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<AddReservationInputType>> { Name = "reservation" }),

                resolve: context =>
                {
                    var reservationInput = context.GetArgument<Reservation>("reservation");
                    return reservationRepository.Add(reservationInput);
                }
            );

            

            Field<ReservationType>("removeReservation",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),

                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return reservationRepository.Remove(id);
                }
            );
        }
    }
}

using GraphQL;
using GraphQL.Types;

namespace Codacious.GraphQL.GraphQL
{
    public class HotelSchema : Schema
    {
        public HotelSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<HotelQuery>();
            Mutation = resolver.Resolve<HotelMutation>();
        }
    }
}

using GraphQL.Types;
using EFCourse.Models;
using EFCourse.Store;

namespace EFCourse.GraphQL {
  public class CourseMutation : ObjectGraphType {
    public CourseMutation(IDataStore dataStore) {
			Field<UniversityType, University>()
				.Name("createUniversity")
				.Argument<NonNullGraphType<UniversityInputType>>("university", "university input")
				.ResolveAsync(ctx => {
          var univ = ctx.GetArgument<University>("university");
          return dataStore.CreateUniversityAsync(univ);
			  });
/*
			Field<OrderType, Order>()
				.Name("createOrder")
				.Argument<NonNullGraphType<OrderInputType>>("order", "order input")
				.ResolveAsync(ctx =>
				{
					var order = ctx.GetArgument<Order>("order");
				    return dataStore.CreateOrderAsync(order);
				});

			Field<CustomerType, Customer>()
                .Name("createCustomer")
                .Argument<NonNullGraphType<CustomerInputType>>("customer", "customer input")
                .ResolveAsync(ctx =>
                {
				    var customer = ctx.GetArgument<Customer>("customer");
                    return dataStore.CreateCustomerAsync(customer);
                });

			Field<OrderItemType, OrderItem>()
				.Name("addOrderItem")
				.Argument<NonNullGraphType<OrderItemInputType>>("orderitem", "orderitem input")
				.ResolveAsync(ctx =>
				{
				    var orderItem = ctx.GetArgument<OrderItem>("orderitem");
				    return dataStore.AddOrderItemAsync(orderItem);
				});
*/
    }
  }
}

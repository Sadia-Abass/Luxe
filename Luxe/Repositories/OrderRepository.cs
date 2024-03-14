using Luxe.Models;

namespace Luxe.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LuxeDbContext _luxeDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(LuxeDbContext luxeDbContext, IShoppingCart shoppingCart)
        {
            _luxeDbContext = luxeDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            // adding the order with its details

            foreach(ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    ProductId = shoppingCartItem.Product.Id,
                    Price = shoppingCartItem.Product.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _luxeDbContext.Orders.Add(order);   
            _luxeDbContext.SaveChanges();
        }
    }
}

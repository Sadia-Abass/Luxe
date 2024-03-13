using Microsoft.EntityFrameworkCore;

namespace Luxe.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly LuxeDbContext _luxeDbContext;
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public ShoppingCart(LuxeDbContext luxeDbContext)
        {
            _luxeDbContext = luxeDbContext; 
        }

        public static ShoppingCart GetCart(IServiceProvider serviceProvider)
        {
            ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
            LuxeDbContext context = serviceProvider.GetService<LuxeDbContext>() ?? throw new Exception("Error initializing");
            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId,
            };
        }

        public void AddToCart(Product product)
        {
            var shoppingCartItem = _luxeDbContext.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem 
                {
                    ShoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };

                _luxeDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }

            _luxeDbContext.SaveChanges();
        }

        public int RemoveFromCart(Product product)
        {
            var shoppingCartitem = _luxeDbContext.ShoppingCartItems.SingleOrDefault(s => s.Product.Id == product.Id && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;

            if(shoppingCartitem == null)
            {
                if(shoppingCartitem.Amount > 1)
                {
                    shoppingCartitem.Amount--;
                    localAmount = shoppingCartitem.Amount;
                }
                else
                {
                    _luxeDbContext.ShoppingCartItems.Remove(shoppingCartitem);
                }
            }

            _luxeDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _luxeDbContext.ShoppingCartItems
                                                       .Where(c => c.ShoppingCartId == ShoppingCartId)
                                                       .Include(s => s.Product)
                                                       .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _luxeDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId != ShoppingCartId);
            _luxeDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _luxeDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total =  _luxeDbContext.ShoppingCartItems
                                       .Where(c => c.ShoppingCartId == ShoppingCartId)
                                       .Select(c => c.Product.Price * c.Amount)
                                       .Sum();
            return total;
        }

        List<ShoppingCartItem> IShoppingCart.ShoppingCartItems()
        {
            throw new NotImplementedException();
        }
    }
}

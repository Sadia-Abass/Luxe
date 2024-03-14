using Luxe.Models;
using Luxe.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Luxe.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;   
        }

        public IActionResult Checkout()
        {
            return View();  
        }
    }
}

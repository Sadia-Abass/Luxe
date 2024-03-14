using Luxe.Models;

namespace Luxe.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}

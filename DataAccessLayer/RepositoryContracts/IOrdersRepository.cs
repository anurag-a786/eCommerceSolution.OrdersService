using eCommerce.OrdersMicroservice.DataAccessLayer.Entities;
using MongoDB.Driver;

namespace DataAccessLayer.RepositoryContracts
{
    public interface IOrdersRepository
    {
        /// <returns>Returns all orders from the orders collection</returns>
        Task<IEnumerable<Order>> GetOrders();

        /// <returns>Returning a collection of matching orders</returns>
        Task<IEnumerable<Order?>> GetOrdersByCondition(FilterDefinition<Order> filter);

        /// <returns>Returning matching order</returns>
        Task<Order?> GetOrderByCondition(FilterDefinition<Order> filter);

        /// <returns>Returns the added Order object or null if unsuccessful</returns>
        Task<Order?> AddOrder(Order order);

        /// <returns>Returns the updated order object; or null if not found</returns>
        Task<Order?> UpdateOrder(Order order);

        /// <returns>Returns true if the deletion is successful, false otherwise</returns>
        Task<bool> DeleteOrder(Guid orderID);

    }
}

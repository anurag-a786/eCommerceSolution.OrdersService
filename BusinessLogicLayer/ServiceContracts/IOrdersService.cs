using DataAccessLayer.Entities;
using eCommerce.OrdersMicroservice.BusinessLogicLayer.DTO;
using MongoDB.Driver;

namespace eCommerce.OrdersMicroservice.BusinessLogicLayer.ServiceContracts
{
    public interface IOrdersService
    {
        /// <returns>Returns list of OrderResponse objects</returns>
        Task<List<OrderResponse?>> GetOrders();

        /// <returns>Returns matching orders as OrderResponse objects</returns>
        Task<List<OrderResponse?>> GetOrdersByCondition(FilterDefinition<Order> filter);

        /// <returns>Returns matching order object as OrderResponse; or null if not found</returns>
        Task<OrderResponse?> GetOrderByCondition(FilterDefinition<Order> filter);

        /// <returns>Returns OrderResponse object that contains order details after inserting; or returns null if 
        /// insertion is unsuccessful.</returns>
        Task<OrderResponse?> AddOrder(OrderAddRequest orderAddRequest);

        /// <returns>Returns order object after successful updation; otherwise null</returns>
        Task<OrderResponse?> UpdateOrder(OrderUpdateRequest orderUpdateRequest);

        /// <returns>Returns true if the deletion is successful; otherwise false</returns>
        Task<bool> DeleteOrder(Guid orderID);
    }
}



using Refit;
using TestTask.Shared.Entities;
using TestTask.Shared.Models;

namespace TestTask.Shared.APIs;

public interface IOrderController
{
    [Post("/api/create-order")]
    Task<OrderEntity> CreateOrder(float money, string cardNumber);

    [Post("/api/get-status")]
    Task<OrderStatus> GetStatusByID(Guid id);
}
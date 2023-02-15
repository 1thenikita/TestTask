using Microsoft.AspNetCore.Mvc;
using TestTask.Shared.Models;
using TestTask.Shared.Entities;

namespace TestTask.WebAPI.Controllers;

[ApiController]
[Route("api")]
public class OrderController : ControllerBase
{
    private DBContext Context;
    private Random Random;
    
    public OrderController(DBContext context)
    {
        Context = context;
        Random = new();
    }

    [HttpPost("create-order")]
    public ActionResult<OrderEntity> CreateOrder(float money, string cardNumber)
    {
        var entity = new OrderEntity()
        {
            Money = money,
            CardNumber = cardNumber
        };

        Context.Orders.Add(entity);
        Context.SaveChanges();
        
        return entity;
    }

    [HttpPost("get-status")]
    public ActionResult<OrderStatus> GetStatusByID(Guid id)
    {
        var entity = Context.Orders.Find(id);
        if (entity == null)
        {
            return NotFound();
        }

        Thread.Sleep(Random.Next(1000, 3000));

        if (entity.Type != OrderStatus.Processing)
        {
            return entity.Type;
        }
        
        var result = entity.Money >= 1000 ? OrderStatus.Success : OrderStatus.Failure;
        entity.Type = result;
        Context.SaveChanges();
        return result;
    }
}
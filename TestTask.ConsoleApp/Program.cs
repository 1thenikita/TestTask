// See https://aka.ms/new-console-template for more information

using Refit;
using Serilog;
using Serilog.Events;
using TestTask.Shared.APIs;
using TestTask.Shared.Entities;
using TestTask.Shared.Models;

// Initialize Serilogger
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Initialize...");
// TODO: по желанию изменить эту строчку.
var hostUrl = "http://localhost:5249";
logger.Information("Host URL: {hostUrl}\n\n", hostUrl);

var api = RestService.For<IOrderController>(hostUrl);
var random = new Random();
while (true)
{
    try
    {
        logger.Information("-----------------------------");
        var money = random.Next(0, 2000);
        var cardNumber = random.Next(1, 20);

        logger.Information($"Money: {money};\tCard: {cardNumber}");
        logger.Information("Create order...");

        var order = await CreateOrder(money, cardNumber.ToString());

        logger.Information("Order created!");

        var result = await GetOrderStatusByID(order.ID);
        logger.Write(result == OrderStatus.Failure ? LogEventLevel.Error : LogEventLevel.Information,
            $"Status: {result}!");
    }
    catch (ApiException exception)
    {
        logger.Error(exception, "Exception with API!");
    }
}

async Task<OrderEntity?> CreateOrder(float money, string cardNumber)
{
    try
    {
        var order = await api.CreateOrder(money, cardNumber.ToString());
        return order;
    }
    catch (ApiException e)
    {
        logger.Error(e, "Exception with API!");
    }

    return null;
}

async Task<OrderStatus> GetOrderStatusByID(Guid id)
{
    var result = OrderStatus.Processing;
    while (result == OrderStatus.Processing)
    {
        logger.Information("Try get order status...");
        Thread.Sleep(2000);
        try
        {
            result = await api.GetStatusByID(id);
        }
        catch (ApiException exception)
        {
            logger.Error(exception, "Exception with API!");
        }
    }

    return result;
}
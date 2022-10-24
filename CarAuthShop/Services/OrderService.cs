using CarAuthShop.Data;
using CarAuthShop.Data.DatabaseObjects;
using CarAuthShop.Services.Infrastructure;

namespace CarAuthShop.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _dbContext;

    public OrderService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> UploadOrderToDatabase(string phoneNumber, string details, string location)
    {
        var order = new OrderDo();

        order.PhoneNumber = phoneNumber;
        order.Details = details;
        order.Location = location;

        _dbContext.OrderDo.Add(order);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}
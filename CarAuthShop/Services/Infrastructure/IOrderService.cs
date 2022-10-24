namespace CarAuthShop.Services.Infrastructure;

public interface IOrderService
{
    Task<bool> UploadOrderToDatabase(string phoneNumber, string details, string location);
}
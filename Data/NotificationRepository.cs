using Microsoft.EntityFrameworkCore;

namespace InventoryMSApi.Data
{
    public class NotificationRepository
    {
        private readonly InventoryDbContext _context;

        public NotificationRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task SendAsync(int id, string message)
        {
            // 🔍 Check if the same notification already exists
            bool exists = await _context.Notifications
                .AnyAsync(n => n.Message.ToLower() == message.ToLower() && n.ProductId == id);

            if (exists)
            {
                // Skip adding duplicate notification
                return;
            }

            var notification = new Models.Notification
            {
                ProductId = id,
                Message = message,
                CreatedAt = DateTime.UtcNow
            };

            _context.Notifications.Add(notification);
            await _context.SaveChangesAsync();
        }

    }
}

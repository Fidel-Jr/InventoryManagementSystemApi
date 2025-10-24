using InventoryMSApi.Data;
using Microsoft.EntityFrameworkCore;

namespace InventoryMSApi.Notifications
{
    public class Notification
    {
        private readonly NotificationRepository _notificationRepository;

        public Notification(NotificationRepository notification)
        {
            _notificationRepository = notification;
        }

        public async Task SendAsync(int id, string message)
        {
            if(id == 0 && message == null)
            {
                return;
            }
            await _notificationRepository.SendAsync(id, message);
        }
    }
}

using InventoryMSApi.Notifications;
using InventoryMSApi.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryMSApi.Jobs
{
    public class BackgroundJob : IHostedService, IDisposable
    {
        private readonly ILogger<BackgroundJob> _logger;
        private readonly IServiceScopeFactory _scopeFactory;
        private Timer? _timer;

        public BackgroundJob(ILogger<BackgroundJob> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(async _ => await CheckLowStockAsync(), null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
            _logger.LogInformation("✅ Background job started.");
            return Task.CompletedTask;
        }

        private async Task CheckLowStockAsync()
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var productService = scope.ServiceProvider.GetRequiredService<ProductService>();
                var notificationService = scope.ServiceProvider.GetRequiredService<Notification>();

                _logger.LogInformation("🔍 Checking low stock products...");

                var lowStockProducts = await productService.GetLowStockProductsAsync(10);

                if (!lowStockProducts.Any())
                {
                    _logger.LogInformation("✅ No low stock products found.");
                    return;
                }

                foreach (var product in lowStockProducts)
                {
                    string message = $"⚠️ Product '{product.ProductName}' is low on stock (Qty: {product.Quantity}).";
                    await notificationService.SendAsync(product.ProductId, message);
                    _logger.LogInformation("📩 Notification added for product: {ProductName}", product.ProductName);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error while checking low stock products.");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("🛑 Background job stopped.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose() => _timer?.Dispose();
    }
}

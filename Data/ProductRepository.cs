using InventoryMSApi.Models;
using InventoryMSApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace InventoryMSApi.Data
{
    public class ProductRepository
    {
        private readonly InventoryDbContext _context;

        public ProductRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> AddAsync(ProductDto productDto)
        {

            var product = new Product
            {
                ProductName = productDto.ProductName,
                ProductDescription = productDto.ProductDescription,
                SKU = productDto.SKU,
                Quantity = productDto.Quantity,
                Threshold = productDto.Threshold,
                Price = productDto.Price,
                ProductImagePath = productDto.ProductImagePath?.FileName
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;

        }

        public async Task DeleteAsync(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
        {
            return await _context.Products
                .Where(p => p.Quantity < threshold)
                .ToListAsync();
        }
    }
}
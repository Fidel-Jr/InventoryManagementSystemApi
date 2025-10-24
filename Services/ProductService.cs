
using InventoryMSApi.Data;
using InventoryMSApi.Models;
using InventoryMSApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace InventoryMSApi.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            return product;
        }

        public async Task<Product> AddProductAsync(ProductDto productDto)
        {
            
            if (string.IsNullOrWhiteSpace(productDto.ProductName))
                throw new ArgumentException("Product name is required.");
            if (string.IsNullOrWhiteSpace(productDto.ProductDescription))
                throw new ArgumentException("Product Description is required.");
            if (string.IsNullOrWhiteSpace(productDto.SKU))
                throw new ArgumentException("SKU is required.");
            if (productDto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");
            if (productDto.Price <= 0)
                throw new ArgumentException("Price must be greater than 0.");
            
            return await _productRepository.AddAsync(productDto);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
                throw new ArgumentException("Product not found");

            if (string.IsNullOrWhiteSpace(productDto.ProductName))
                throw new ArgumentException("Product name is required.");
            if (string.IsNullOrWhiteSpace(productDto.ProductDescription))
                throw new ArgumentException("Product Description is required.");        
            if (string.IsNullOrWhiteSpace(productDto.SKU))
                throw new ArgumentException("SKU is required.");
            if (productDto.Quantity <= 0)
                throw new ArgumentException("Quantity must be greater than 0.");
            if (productDto.Price <= 0)
                throw new ArgumentException("Price must be greater than 0.");

            product.ProductName = productDto.ProductName;
            product.ProductDescription = productDto.ProductDescription;
            product.SKU = productDto.SKU;
            product.Price = productDto.Price;
            product.Quantity = productDto.Quantity;
            product.Threshold = productDto.Threshold;
            product.ProductImagePath = productDto.ProductImagePath?.FileName;

            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found.");
            }
            await _productRepository.DeleteAsync(product);
        }

        public async Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
        {
            var products = await _productRepository.GetLowStockProductsAsync(threshold);

            // Example business logic:
            // Maybe exclude discontinued products or inactive ones
            return products;
        }

    }
}

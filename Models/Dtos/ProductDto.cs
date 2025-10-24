namespace InventoryMSApi.Models.Dtos
{
    public class ProductDto
    {
        public required string ProductName { get; set; }
        public required string ProductDescription { get; set; }
        public required string SKU { get; set; }
        public IFormFile? ProductImagePath { get; set; }
        public int Quantity { get; set; }
        public int Threshold { get; set; }
        public decimal Price { get; set; }
    }
}
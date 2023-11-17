namespace HasMicroService.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal PriceEUR { get; set; }
        public decimal PriceUSD { get; set; }
        public int CategoryId { get; set; }

    }
}

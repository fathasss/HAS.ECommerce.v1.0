using HasMicroService.DbContexts;
using HasMicroService.Models;
using Microsoft.EntityFrameworkCore;

namespace HasMicroService.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;

        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public IEnumerable<Product> GetProduct()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public void InsertProduct(Product product)
        {
            product.PriceUSD = Math.Round(product.Price / _dbContext.Currencies.Where(x => x.Id == Convert.ToInt32(CurrencyItem.USD)).FirstOrDefault().Ratio,2);
            product.PriceEUR = Math.Round(product.Price / _dbContext.Currencies.Where(x => x.Id == Convert.ToInt32(CurrencyItem.EUR)).FirstOrDefault().Ratio,2);
            _dbContext.Add(product);
            Save();
        }

        public void Save()
        {            
            _dbContext.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
            Save();
        }
    }
}

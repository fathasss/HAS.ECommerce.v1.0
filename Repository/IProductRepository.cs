using HasMicroService.Models;

namespace HasMicroService.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProduct();
        Product GetProductById(int id);

        void InsertProduct(Product product);

        void UpdateProduct(Product product);
        void DeleteProduct(int id);

        void Save();
    }
}

using Estudo.Entities;

namespace Estudo.Interfaces;

public interface IProductRepository
{
    public Task<List<Product>> ListProducts();
    public Task AddProduct(Product newProduct);
    public Task<Product> EditProduct(int id, Product editedProduct);
    public Task DeleteProduct(int id);
}

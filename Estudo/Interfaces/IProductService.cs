using Estudo.Class.DTOs.Products;
using Estudo.Entities;

namespace Estudo.Interfaces;

public interface IProductService
{
    public Task<List<Product>> GetListProducts();
    public Task AddProduct(ProductRequest newProduct);
    public Task<Product> EditProduct(int id, ProductRequest editedProduct);
    public Task DeleteProduct(int id);
}

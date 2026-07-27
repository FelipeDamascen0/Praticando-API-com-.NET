using Estudo.Class;
using Estudo.Class.Request;
using Estudo.Interfaces;
using Estudo.Repository;

namespace Estudo.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository ProductRepository;
    public ProductService(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public async Task<List<Product>> GetListProducts()
    {
        return await ProductRepository.ListProducts();
    }

    public async Task AddProduct(ProductRequest newProduct)
    {

        Product product = new Product()
        {
            Name = newProduct.Name,
            Price = newProduct.Price
        };
        await ProductRepository.AddProduct(product);
    }

    public async Task<Product> EditProduct(int id, ProductRequest editedProduct)
    {
        Product produto = new Product()
        {
            Name = editedProduct.Name,
            Price = editedProduct.Price
        };

        return await ProductRepository.EditProduct(id, produto);
    }

    public async Task DeleteProduct(int id)
    {
        await ProductRepository.DeleteProduct(id);
    }
}

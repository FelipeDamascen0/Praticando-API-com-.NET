using Estudo.AppDbContext;
using Estudo.Class;
using Estudo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estudo.Repository;

public class ProductRepository : IProductRepository
{
    private readonly AppProductContext Context;
    public ProductRepository(AppProductContext ctx)
    {
        Context = ctx;
    }
    public async Task<List<Product>> ListProducts()
    {
        try
        {
            List<Product> listProducts = await Context.Product.ToListAsync();

            return listProducts;
        }
        catch (Exception)
        {
            throw;
        }

    }

    public async Task AddProduct(Product newProduct)
    {
        ValidateProduct(newProduct);
        await Context.Product.AddAsync(newProduct);
        await Context.SaveChangesAsync();
    }

    private void ValidateProduct(Product product)
    {
        if (Context.Product.Any(p => p.Name == product.Name)) 
            throw new Exception("O nome desse produto já está sendo usado. Porfavor utilize outro nome");

        if (String.IsNullOrEmpty(product.Name)) 
            throw new Exception("O Produto deve ter um nome valido de até 3 caracteres");

        if (product.Price <= 0) 
            throw new Exception("O Produto deve ter um preco maior que 0");
    }

    public async Task<Product> EditProduct(int id, Product editedProduct)
    {
        var product = await Context.Product.FindAsync(id);

        if (product is null) throw new Exception("Produto não encontrado");

        product.Name = editedProduct.Name;
        product.Price = editedProduct.Price;
        Context.Update(product);
        await Context.SaveChangesAsync();

        return product;
    }

    public async Task DeleteProduct(int id)
    {
        var deletedProduct = await Context.Product.FindAsync(id);

        if (deletedProduct is null) throw new Exception("Esse Produto não existe");

        Context.Product.Remove(deletedProduct);
        await Context.SaveChangesAsync();
    }
}

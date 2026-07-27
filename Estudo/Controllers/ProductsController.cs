using Estudo.Class;
using Estudo.Class.Request;
using Estudo.Interfaces;
using Estudo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Estudo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService ProductService;
        public ProductsController(IProductService productService)
        {
            ProductService = productService;
        }

        [HttpGet("list-product")]
        public async Task<IActionResult> GetListProduct() 
        {
            try
            {
                List<Product> products = await ProductService.GetListProducts();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] ProductRequest newProduct) 
        {
            try
            {
                await ProductService.AddProduct(newProduct);

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPut("edit-product/{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductRequest editedProduct)
        {
            try
            {
                Product product = await ProductService.EditProduct(id, editedProduct);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            try
            {
                await ProductService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

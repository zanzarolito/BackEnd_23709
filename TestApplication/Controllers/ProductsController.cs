using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApplication.Data;
using TestApplication.DTO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TestApplication.Models;
using DTO;


namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var product = from products in _context.Product
                          join product_descriptions in _context.Product_Description on products.id equals product_descriptions.product_id
                          select new ProductDTO
                          {
                           Product_id = products.id,
                           Product_price = products.price,
                           ISBN = products.isbn,
                           Product_name = product_descriptions.product_name,
                           Product_description = product_descriptions.product_description
                          };

            return await product.ToListAsync();
        }


        private bool ProductExists(int id)
        {
            return _context.Product.Any(x => x.id == id);
        }
    }
}
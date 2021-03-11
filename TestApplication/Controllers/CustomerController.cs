using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TestApplication.Data;
using TestApplication.DTO;



namespace backend_database_HTTP_Requests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly Context _context;
        public CustomersController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomers()
        {
            var student = from customers in _context.Customers
                          join customers_descriptions in _context.customers_Description on customers.Id equals customers_descriptions.Customers_id
                          select new CustomerDTO
                          {
                              Customer_id = customers.Id,
                              First_name = customers_descriptions.first_name,
                              Last_name = customers_descriptions.last_name,
                              Mail = customers_descriptions.mail
                              
                          };

            return await student.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<CustomerDTO> GetCustomers_byId(int id)
        {
            var product = from products in _context.Product
                       join product_descriptions in _context.Product_Description on products.id equals product_descriptions.product_id
                       join shop in _context.Shop on products.id equals shop.Product_id
                       select new ProductDTO
                       {
                           Product_id = products.id,
                           Product_price = products.price,
                           ISBN = products.isbn,
                           Product_name = product_descriptions.product_name,
                           Product_description = product_descriptions.product_description,
                           Date_time = shop.Date_time,
                           Customer_id = Shop.Customer_id,
                           Id = Shop.Id
                       };

            var customer = from customers in _context.Customers
                           join customers_descriptions in _context.customers_Description on customers.Id equals customers_descriptions.Customers_id
                           join Shop in _context.Shop on customers.Id equals Shop.Customer_id
                           select new CustomerDetailsDTO
                          {
                              Customer_id = customers.Id,
                              First_name = customers_descriptions.first_name,
                              Last_name = customers_descriptions.last_name,
                              Mail = customers_descriptions.mail,
                              Products = product.Where(x => x.Product_id == shop.Product_id).ToList()
                          };

            var customer_by_id = customer.ToList().Find(x => x.Customer_id == id);

            if (customer_by_id == null)
            {
                return NotFound();
            }
            return customer_by_id;
        }


      
    }
}
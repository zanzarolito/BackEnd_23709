using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using TestApplication.Data;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly Context _context;

        public OrderController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shop>>> GetOrder()
        {
            return await _context.Shop.ToListAsync();
        }

        [HttpPost("buy")]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Order(OrderDTO request)
        {
            foreach (var item in request.products)
            {
                var shop = new Shop()
                {
                    Customer_id = request.Customer_id,
                    Product_id = item,
                    Date_time = DateTime.UtcNow,
                 
                };
                await _context.Shop.AddAsync(shop);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetOrder", request);
        }

        

        
    }
}
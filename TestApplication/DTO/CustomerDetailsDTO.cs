using System.Collections.Generic;
using Models;
using TestApplication.DTO;

namespace DTO
{
    public class CustomerDetailsDTO : CustomerDTO
    {
        public List<ProductDTO> Products { get; set; }
    }
}
using System.Collections.Generic;

namespace DTO
{
    public class OrderDTO
    {
        public int Customer_id { get; set; }
        public List<int> products {get; set;}
    }
}
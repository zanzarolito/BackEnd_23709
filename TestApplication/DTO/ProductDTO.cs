using Models;

namespace TestApplication.DTO
{
    public class ProductDTO : Shop
    {
        public decimal Product_price { get; set; }
        public string ISBN { get; set; }
        public string Product_name { get; set; }
        public string Product_description { get; set; }
    }
}
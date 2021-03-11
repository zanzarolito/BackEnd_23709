using System.ComponentModel.DataAnnotations;

namespace TestApplication.Models
{
    public class Product_description
    {
        [Key]
        public int id { get; set; }
        public int product_id { get; set; }
        public string product_name { get; set; }
        public string product_description { get; set; }
    }
}
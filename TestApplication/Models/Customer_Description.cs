using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customers_Description
    {
        [Key]
        public int Id { get; set; }
        public int Customers_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string mail { get; set; }

    }
}
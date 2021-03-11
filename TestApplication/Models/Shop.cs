using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }
        public int Customer_id { get; set; }
        public int Product_id { get; set; }
        public DateTime Date_time { get; set; }

    }
}
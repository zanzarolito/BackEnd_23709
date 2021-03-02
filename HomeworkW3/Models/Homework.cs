using System.ComponentModel.DataAnnotations;

namespace Homework_0302.Models
{
    public class Homework
    {
        [Key]
        public int Grade { get; set; }
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ProductWebAPI_With_DB.models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required]
        [Range(0.1, 5000)]
        public double Price { get; set; }
        public int Qty { get; set; }
        public double amount { get => Price * Qty; }
    }
}



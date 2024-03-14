using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPI.Models
{
    public class SparePart
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int? CategoryId { get; set; }
       
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier? Supplier { get; set; }
    }
}

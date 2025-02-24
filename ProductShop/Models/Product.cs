using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Barcode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        [Required]
        public decimal PurchasePrice { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [StringLength(255)]
        public string? Notes { get; set; }
    }
}

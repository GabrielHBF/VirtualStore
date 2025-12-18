using System.ComponentModel.DataAnnotations;
using VirtualStore.ProductApi.Model;

namespace VirtualStore.ProductApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        [MinLength(10)]
        [MaxLength(100)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Stock field is rquired.")]
        [Range(1,999)]
        public long Stock { get; set; }
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}

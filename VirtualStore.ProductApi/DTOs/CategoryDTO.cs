using System.ComponentModel.DataAnnotations;
using VirtualStore.ProductApi.Model;

namespace VirtualStore.ProductApi.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}

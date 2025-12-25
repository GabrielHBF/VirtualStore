using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VirtualStore.Web.Models;

public class ProductsViewModel
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public long Stock { get; set; }
    [Required]
    public string? ImageUrl { get; set; }
    public string? CategoryName { get; set; }
    public int CategoryId { get; set; }
}

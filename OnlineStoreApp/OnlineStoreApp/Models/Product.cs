using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool IsAvailable { get; set; } = true;

        // Навігаційні властивості
        public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<CartItem>? CartItems { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = string.Empty;

        [Required]
        [StringLength(200)]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required]
        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending";

        // Навігаційні властивості
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}

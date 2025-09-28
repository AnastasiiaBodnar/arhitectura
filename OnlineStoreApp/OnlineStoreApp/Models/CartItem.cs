using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int CartId { get; set; }
        public Cart? Cart { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        public string SessionId { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
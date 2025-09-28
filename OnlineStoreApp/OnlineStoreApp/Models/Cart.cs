using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string SessionId { get; set; } = string.Empty;
        public int? UserId { get; set; }
        public User? User { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public ICollection<CartItem>? CartItems { get; set; }
    }
}
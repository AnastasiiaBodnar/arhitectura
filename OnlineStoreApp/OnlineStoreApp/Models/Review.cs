using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }
        public int? ModeratorId { get; set; }
        public Moderator? Moderator { get; set; }
        public bool IsApproved { get; set; } = false;
        public DateTime? ApprovalDate { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime ReviewDate { get; set; } = DateTime.Now;
    }
}
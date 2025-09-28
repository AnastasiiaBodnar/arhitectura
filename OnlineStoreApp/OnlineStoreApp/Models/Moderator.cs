﻿using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Moderator
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public DateTime HireDate { get; set; } = DateTime.Now;

        // Навігаційні властивості
        public ICollection<Review>? ModeratedReviews { get; set; }
    }
}
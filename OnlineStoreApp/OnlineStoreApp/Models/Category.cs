﻿using System.ComponentModel.DataAnnotations;

namespace OnlineStoreApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        // Навігаційні властивості
        public ICollection<Product>? Products { get; set; }
    }
}
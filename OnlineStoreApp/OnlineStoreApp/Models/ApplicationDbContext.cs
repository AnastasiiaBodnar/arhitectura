using Microsoft.EntityFrameworkCore;

namespace OnlineStoreApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets для наших моделей
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Moderator> Moderators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Конфігурація зв'язків
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Moderator)
                .WithMany(m => m.ModeratedReviews)
                .HasForeignKey(r => r.ModeratorId);

            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId);

            // Додавання початкових категорій
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Електроніка", Description = "Електронні пристрої" },
                new Category { Id = 2, Name = "Одяг", Description = "Чоловічий та жіночий одяг" },
                new Category { Id = 3, Name = "Книги", Description = "Книги різних жанрів" }
            );

            // Додавання тестових товарів
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "iPhone 15 Pro",
                    Description = "Новітній смартфон Apple з титановим корпусом та системою камер Pro",
                    Price = 35999m,
                    CategoryId = 1,
                    IsAvailable = true,
                    ImageUrl = "https://via.placeholder.com/300x200?text=iPhone+15+Pro"
                },
                new Product
                {
                    Id = 2,
                    Name = "Samsung Galaxy S24",
                    Description = "Флагманський Android смартфон з AI функціями",
                    Price = 28999m,
                    CategoryId = 1,
                    IsAvailable = true,
                    ImageUrl = "https://via.placeholder.com/300x200?text=Galaxy+S24"
                },
                new Product
                {
                    Id = 3,
                    Name = "MacBook Air M3",
                    Description = "Ультрапортативний ноутбук Apple з чіпом M3",
                    Price = 45999m,
                    CategoryId = 1,
                    IsAvailable = true,
                    ImageUrl = "https://via.placeholder.com/300x200?text=MacBook+Air"
                },
                new Product
                {
                    Id = 4,
                    Name = "Чоловіча сорочка",
                    Description = "Класична бавовняна сорочка для офісу та повсякденного носіння",
                    Price = 1299m,
                    CategoryId = 2,
                    IsAvailable = true,
                    ImageUrl = "https://via.placeholder.com/300x200?text=Сорочка"
                },
                new Product
                {
                    Id = 5,
                    Name = "Жіноче плаття",
                    Description = "Елегантне літнє плаття з натуральних тканин",
                    Price = 2499m,
                    CategoryId = 2,
                    IsAvailable = true,
                    ImageUrl = "https://via.placeholder.com/300x200?text=Плаття"
                },
                new Product
                {
                    Id = 6,
                    Name = "Програмування на C#",
                    Description = "Повний посібник з програмування на мові C# для початківців",
                    Price = 899m,
                    CategoryId = 3,
                    IsAvailable = true,
                    ImageUrl = "https://via.placeholder.com/300x200?text=C%23+Book"
                }
            );
        }
    }
}
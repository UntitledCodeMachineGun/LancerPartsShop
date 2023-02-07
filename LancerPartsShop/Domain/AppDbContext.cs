using LancerPartsShop.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace LancerPartsShop.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<BlogItem> BlogItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "e4b29369-89aa-429c-96d4-2bd5267523c2",
                Name = "admin",
                NormalizedName= "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "7e61803d-b0bf-4db9-b850-a9ff9c75b496",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "lancerparts@email.com",
                NormalizedEmail = "LANCERPARTS@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "mypassword"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            { 
                RoleId = "e4b29369-89aa-429c-96d4-2bd5267523c2",
                UserId = "7e61803d-b0bf-4db9-b850-a9ff9c75b496"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("deae2a12-08d2-4ef7-be64-f47d18264ca0"),
                CodeWord = "PageIndex",
                Name = "Lancer Parts",
				Description = "Index page"
			});

			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("3e23fdbf-2c09-484e-bff4-ac7acefae890"),
				CodeWord = "PageBlog",
				Name = "Blog",
				Description = "Blog page"
			});

			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("3de47f54-f02d-4c98-a64f-b5313b885f9e"),
				CodeWord = "ContactsPage",
				Name = "Contacts",
				Description = "Contacts page"
			});

			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("913507db-c5ce-4bc2-b1f9-5e54fe570873"),
				CodeWord = "DeliveryInfo",
				Name = "Delivery",
				Description = "Delivery Info"
			});

			builder.Entity<TextField>().HasData(new TextField
			{
				Id = new Guid("08050526-d33e-40e9-b98d-e9f9b8160f77"),
				CodeWord = "PaymentInfo",
				Name = "Payment",
				Description = "Payment Info"
			});
		}
    }
}

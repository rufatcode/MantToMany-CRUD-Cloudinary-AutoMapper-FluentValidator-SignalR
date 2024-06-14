using System;
using Lab10_FrontToBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab10_FrontToBack.DataContext
{
	public class AppDbContext: IdentityDbContext<AppUser>
    {
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<ProductTag> ProductTags { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ChatMessage> ChatMessages { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
		{
		}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            builder.Entity<ChatMessage>()
               .HasOne(m => m.FromUser)
               .WithMany(u => u.SentMessages)
               .HasForeignKey(m => m.FromUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ChatMessage>()
                .HasOne(m => m.ToUser)
                .WithMany(u => u.ReceivedMessages)
                .HasForeignKey(m => m.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);
           
            string AdminRoleId = Guid.NewGuid().ToString();
            string SupperAdminRoleId = Guid.NewGuid().ToString();
            string UserRoleId = Guid.NewGuid().ToString();
            string AdminId = Guid.NewGuid().ToString();
            string RashadId = Guid.NewGuid().ToString();
            string IlgarId = Guid.NewGuid().ToString();
            string SupperAdminId = Guid.NewGuid().ToString();
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = AdminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = SupperAdminRoleId,
                Name = "SupperAdmin",
                NormalizedName = "SUPPERADMIN"
            },
            new IdentityRole
            {
                Id = UserRoleId,
                Name = "User",
                NormalizedName = "USER"
            });
            AppUser Admin = new AppUser
            {
                Id = AdminId,
                Email = "rufatri@code.edu.az",
                NormalizedEmail = "RUFATRI@CODE.EDU.AZ",
                NormalizedUserName = "RUFATCODE",
                UserName = "RufatCode",
                EmailConfirmed = true,
                IsActive = true,
                FullName = "Rufat Azerbaijan",
                PhoneNumber = "+994513004484",
                PhoneNumberConfirmed = true,
                Created = DateTime.Now,
            };
            AppUser SupperAdmin = new AppUser
            {
                Id = SupperAdminId,
                Email = "rft.smayilov@bk.ru",
                NormalizedEmail = "RFT.SMAYILOV@BK.RU",
                NormalizedUserName = "RUFAT_2003",
                UserName = "Rufat_2003",
                EmailConfirmed = true,
                IsActive = true,
                FullName = "Rufat Code",
                PhoneNumber = "+994513004484",
                PhoneNumberConfirmed = true,
                Created = DateTime.Now,

            };
            AppUser Rashad = new AppUser
            {
                Id = RashadId,
                Email = "rashad123@code.edu.az",
                NormalizedEmail = "RASHAD123@CODE.EDU.AZ",
                NormalizedUserName = "RASHAD12",
                UserName = "Rashad12",
                EmailConfirmed = true,
                IsActive = true,
                FullName = "Rashad",
                PhoneNumber = "+994513004484",
                PhoneNumberConfirmed = true,
                Created = DateTime.Now,
            };
            AppUser Ilgar = new AppUser
            {
                Id = IlgarId,
                Email = "ilgar@code.edu.az",
                NormalizedEmail = "Ilgar@CODE.EDU.AZ",
                NormalizedUserName = "Ilgar123",
                UserName = "Ilgar123",
                EmailConfirmed = true,
                IsActive = true,
                FullName = "Ilgar",
                PhoneNumber = "+994513004484",
                PhoneNumberConfirmed = true,
                Created = DateTime.Now,
            };
            PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
            string AdminPassword = hasher.HashPassword(Admin, "Rufat123.");
            string SupperAdminPassword = hasher.HashPassword(Admin, "Rufat123.");
            string RashadPassword = hasher.HashPassword(Rashad, "Rufat123.");
            string IlgarPassword = hasher.HashPassword(Ilgar, "Rufat123.");
            Admin.PasswordHash = AdminPassword;
            SupperAdmin.PasswordHash = SupperAdminPassword;
            Rashad.PasswordHash = SupperAdminPassword;
            Ilgar.PasswordHash = SupperAdminPassword;
            builder.Entity<AppUser>().HasData(Admin);
            builder.Entity<AppUser>().HasData(SupperAdmin);
            builder.Entity<AppUser>().HasData(Rashad);
            builder.Entity<AppUser>().HasData(Ilgar);
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = AdminId,
                RoleId = AdminRoleId

            },
            new IdentityUserRole<string>
            {
                UserId = SupperAdminId,
                RoleId = SupperAdminRoleId,


            });
            base.OnModelCreating(builder);
        }

    }
}


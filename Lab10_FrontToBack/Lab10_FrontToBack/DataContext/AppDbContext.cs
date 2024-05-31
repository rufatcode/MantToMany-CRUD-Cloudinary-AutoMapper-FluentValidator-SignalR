using System;
using Lab10_FrontToBack.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10_FrontToBack.DataContext
{
	public class AppDbContext:DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<ProductTag> ProductTags { get; set; }
		public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
		{
		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


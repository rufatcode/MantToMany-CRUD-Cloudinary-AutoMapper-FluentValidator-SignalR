using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.Models
{
	public class Product:BaseEntity
	{
		[ForeignKey(nameof(Brand))]
		public int BrandId { get; set; }
		public Brand Brand { get; set; }
		public List<ProductTag> ProductTags { get; set; }
		[ForeignKey(nameof(Category))]
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public string Name { get; set; }
		public List<ProductImages> ProductImages { get; set; }
		//public string MainImageUrl { get; set; }
		//public string MainImagePublicId { get; set; }
		//public string HoverImageUrl { get; set; }
		//public string HoverImagePublicId { get; set; }
		public Product()
		{
			ProductImages = new();
			ProductTags = new();
		}
	}
}


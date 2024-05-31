using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.Models
{
	public class ProductImages:BaseEntity
	{
		public string Url { get; set; }
		public string  PublicId { get; set; }
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }

		public ProductImages()
		{
		}
	}
}


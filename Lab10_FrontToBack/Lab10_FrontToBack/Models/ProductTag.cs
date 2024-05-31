using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.Models
{
	public class ProductTag:BaseEntity
	{
		[ForeignKey(nameof(Product))]
		public int ProductId { get; set; }
		public Product Product { get; set; }
		[ForeignKey(nameof(Tag))]
		public int TagId { get; set; }
		public Tag Tag { get; set; }
		public ProductTag()
		{
		}
	}
}


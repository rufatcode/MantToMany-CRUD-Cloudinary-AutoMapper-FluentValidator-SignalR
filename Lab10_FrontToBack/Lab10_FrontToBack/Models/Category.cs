using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.Models
{
	public class Category:BaseEntity
	{
		public string ImageUrl { get; set; }
		public string PublicId { get; set; }
		public string Name { get; set; }
		[ForeignKey(nameof(Category))]
		public int? ParentId { get; set; }
        public Category Parent { get; set; }
        public List<Category> SubCategoiries { get; set; }
		public Category()
		{
		}
	}
}


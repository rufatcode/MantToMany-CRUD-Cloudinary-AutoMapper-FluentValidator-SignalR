using System;
using Lab10_FrontToBack.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.ViewModels.ProductVM
{
	public class GetProductVM
	{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public string BrandName { get; set; }
        public List<ProductTagVM> ProductTags { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public List<ProductImages> ProductImages { get; set; }
        public GetProductVM()
		{
		}
	}
}


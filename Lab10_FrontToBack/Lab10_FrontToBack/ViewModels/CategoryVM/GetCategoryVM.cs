using System;
using Lab10_FrontToBack.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.ViewModels.CategoryVM
{
	public class GetCategoryVM
	{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public string ImageUrl { get; set; }
        public string PublicId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string? ParentName { get; set; }
        public int SubCategoiriesCount { get; set; }
        public GetCategoryVM()
		{
		}
	}
}


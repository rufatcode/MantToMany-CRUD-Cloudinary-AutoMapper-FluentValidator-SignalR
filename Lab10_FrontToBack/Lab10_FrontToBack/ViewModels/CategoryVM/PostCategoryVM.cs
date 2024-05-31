using System;
using Lab10_FrontToBack.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Lab10_FrontToBack.ViewModels.CategoryVM
{
	public class PostCategoryVM
	{
        public IFormFile Image { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public PostCategoryVM()
		{
		}
	}
}


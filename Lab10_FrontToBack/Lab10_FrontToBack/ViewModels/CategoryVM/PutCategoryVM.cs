using System;
namespace Lab10_FrontToBack.ViewModels.CategoryVM
{
	public class PutCategoryVM
	{
        public IFormFile? Image { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public PutCategoryVM()
		{
		}
	}
}


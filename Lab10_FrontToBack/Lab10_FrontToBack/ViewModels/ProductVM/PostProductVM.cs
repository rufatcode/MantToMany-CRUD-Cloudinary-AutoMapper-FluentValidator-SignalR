using System;
using Lab10_FrontToBack.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab10_FrontToBack.ViewModels.ProductVM
{
	public class PostProductVM
	{
        public int BrandId { get; set; }
        public List<int> TagIds { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<IFormFile> Images { get; set; }
        public PostProductVM()
		{
		}
	}
}


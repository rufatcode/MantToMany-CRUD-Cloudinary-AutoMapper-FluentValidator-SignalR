using System;
namespace Lab10_FrontToBack.ViewModels.ProductVM
{
	public class PutProductVM
	{
        public int BrandId { get; set; }
        public List<int>? TagIds { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<IFormFile>? Images { get; set; }
        public PutProductVM()
		{
		}
	}
}


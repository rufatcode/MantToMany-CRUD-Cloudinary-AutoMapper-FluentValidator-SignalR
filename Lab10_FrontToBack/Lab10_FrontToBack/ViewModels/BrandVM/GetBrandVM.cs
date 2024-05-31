using System;
namespace Lab10_FrontToBack.ViewModels.BrandVM
{
	public class GetBrandVM
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> UpdatedAt { get; set; }
        public GetBrandVM()
		{
		}
	}
}


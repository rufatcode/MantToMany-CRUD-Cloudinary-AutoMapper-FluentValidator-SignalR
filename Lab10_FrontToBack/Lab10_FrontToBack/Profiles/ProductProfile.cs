using System;
using AutoMapper;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.ProductVM;

namespace Lab10_FrontToBack.Profiles
{
	public class ProductProfile:Profile
	{
		public ProductProfile()
		{
			CreateMap<Product, GetProductVM>().ReverseMap();
			CreateMap<Product, PostProductVM>().ReverseMap();
			CreateMap<Product, PutProductVM>().ReverseMap();
			CreateMap<ProductTagVM, ProductTag>().ReverseMap();
        }
	}
}


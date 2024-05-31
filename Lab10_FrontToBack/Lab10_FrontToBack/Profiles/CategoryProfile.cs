using System;
using AutoMapper;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.CategoryVM;

namespace Lab10_FrontToBack.Profiles
{
	public class CategoryProfile:Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, GetCategoryVM>().ReverseMap();
			CreateMap<Category, PostCategoryVM>().ReverseMap();
			CreateMap<Category, PutCategoryVM>().ReverseMap();

        }
	}
}


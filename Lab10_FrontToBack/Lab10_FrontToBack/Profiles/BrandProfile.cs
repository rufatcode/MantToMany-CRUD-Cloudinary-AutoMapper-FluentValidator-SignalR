using System;
using AutoMapper;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.BrandVM;

namespace Lab10_FrontToBack.Profiles
{
	public class BrandProfile:Profile
	{
		public BrandProfile()
		{
			CreateMap<Brand, GetBrandVM>()
				.ReverseMap()
				.ForMember(t=>t.Name,map=>map.MapFrom(gb=>gb.Name));
			CreateMap<Brand, PostBrandVM>().ReverseMap();
			CreateMap<Brand, PutBrandVM>().ReverseMap();
        }
	}
}


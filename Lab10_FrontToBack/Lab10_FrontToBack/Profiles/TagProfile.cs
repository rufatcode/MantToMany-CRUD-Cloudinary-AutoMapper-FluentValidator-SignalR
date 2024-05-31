using System;
using AutoMapper;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.TagVM;

namespace Lab10_FrontToBack.Profiles
{
	public class TagProfile:Profile
	{
		public TagProfile()
		{
			CreateMap<Tag, PostTagVM>().ReverseMap();
			CreateMap<Tag, GetTagVM>().ReverseMap();
			CreateMap<Tag, PutTagVM>().ReverseMap();
        }
	}
}


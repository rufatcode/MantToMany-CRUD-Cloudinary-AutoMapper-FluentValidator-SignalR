using System;
using AutoMapper;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.ViewModels.UsersVM;

namespace Lab10_FrontToBack.Profiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<AppUser, GetUserVM>();
            CreateMap<AppUser, UserUpdateVM>();
            CreateMap<UserUpdateVM, AppUser>();
        }
    }
}


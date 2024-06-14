using System;
using FluentValidation.AspNetCore;
using Lab10_FrontToBack.Configurations;
using Lab10_FrontToBack.DataContext;
using Lab10_FrontToBack.Models;
using Lab10_FrontToBack.Profiles;
using Lab10_FrontToBack.Services;
using Lab10_FrontToBack.Services.Interfaces;
using Lab10_FrontToBack.Validators.BrandValidators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Lab10_FrontToBack
{
	public static class ServiceRegistration
	{
		public static void Registarion(this IServiceCollection services,IConfiguration configuration)
		{
            services.AddRazorPages();
            services.AddSignalR();
            services.AddFluentValidation(d => d.RegisterValidatorsFromAssemblyContaining<PutBrandValidadtor>());
            services.AddAutoMapper(typeof(BrandProfile).Assembly);
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedEmail = true;
                option.Password.RequireDigit = true;
                option.Password.RequiredLength = 8;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                option.SignIn.RequireConfirmedAccount = true;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddHttpContextAccessor();
            services.Configure<DataProtectionTokenProviderOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromMinutes(10);

            });
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<ISendEmail, SendEmail>();
        }
	}
}


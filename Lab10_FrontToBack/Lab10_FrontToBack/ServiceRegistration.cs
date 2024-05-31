using System;
using FluentValidation.AspNetCore;
using Lab10_FrontToBack.Configurations;
using Lab10_FrontToBack.DataContext;
using Lab10_FrontToBack.Profiles;
using Lab10_FrontToBack.Services;
using Lab10_FrontToBack.Services.Interfaces;
using Lab10_FrontToBack.Validators.BrandValidators;
using Microsoft.EntityFrameworkCore;

namespace Lab10_FrontToBack
{
	public static class ServiceRegistration
	{
		public static void Registarion(this IServiceCollection services,IConfiguration configuration)
		{
            services.AddRazorPages();
            services.AddFluentValidation(d => d.RegisterValidatorsFromAssemblyContaining<PutBrandValidadtor>());
            services.AddAutoMapper(typeof(BrandProfile).Assembly);
            services.Configure<CloudinarySettings>(configuration.GetSection("Cloudinary"));
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IFileService, FileService>();
        }
	}
}


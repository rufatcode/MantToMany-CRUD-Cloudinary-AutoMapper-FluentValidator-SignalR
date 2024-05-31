using System;
using FluentValidation;
using Lab10_FrontToBack.ViewModels.BrandVM;

namespace Lab10_FrontToBack.Validators.BrandValidators
{
	public class PostBrandValidator: AbstractValidator<PostBrandVM>
    {
		public PostBrandValidator()
		{
			RuleFor(b => b.Name).MinimumLength(5).WithMessage("Name length must be greater than 5")
				.MaximumLength(100).WithMessage("Name length must be smaller than 100");
		}
	}
}


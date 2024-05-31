using System;
using FluentValidation;
using Lab10_FrontToBack.ViewModels.BrandVM;

namespace Lab10_FrontToBack.Validators.BrandValidators
{
	public class PutBrandValidadtor:AbstractValidator<PutBrandVM>
	{
		public PutBrandValidadtor()
		{
            RuleFor(b => b.Name).MinimumLength(5).WithMessage("Name length must be greater than 5")
                .MaximumLength(100).WithMessage("Name length must be smaller than 100");
        }
	}
}


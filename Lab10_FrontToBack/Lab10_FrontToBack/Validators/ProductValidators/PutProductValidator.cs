using System;
using FluentValidation;
using Lab10_FrontToBack.ViewModels.ProductVM;

namespace Lab10_FrontToBack.Validators.ProductValidators
{
	public class PutProductValidator:AbstractValidator<PutProductVM>
	{
		public PutProductValidator()
		{
			RuleFor(p => p.Name)
				.MinimumLength(5).WithMessage("length of name must be greater than 5")
				.MaximumLength(100).WithMessage("length of name must be smaller than 100");
           

        }
	}
}


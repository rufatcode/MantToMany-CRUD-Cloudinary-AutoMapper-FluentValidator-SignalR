using System;
using FluentValidation;
using Lab10_FrontToBack.ViewModels.CategoryVM;

namespace Lab10_FrontToBack.Validators.CategoryValidator
{
	public class PostCategoryValidator:AbstractValidator<PostCategoryVM>
	{
		public PostCategoryValidator()
		{
			RuleFor(c => c.Name)
				.MinimumLength(5).WithMessage("length of name must be greater than 5")
				.MaximumLength(100).WithMessage("length of name must be smaller than 100");
		}
	}
}


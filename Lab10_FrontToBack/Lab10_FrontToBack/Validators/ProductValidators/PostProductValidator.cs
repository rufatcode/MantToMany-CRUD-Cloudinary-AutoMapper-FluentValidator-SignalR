using System;
using FluentValidation;
using Lab10_FrontToBack.ViewModels.ProductVM;

namespace Lab10_FrontToBack.Validators.ProductValidators
{
	public class PostProductValidator:AbstractValidator<PostProductVM>
	{
		public PostProductValidator()
		{
            RuleFor(p => p.Name)
                .MinimumLength(5).WithMessage("length of name must be greater than 5")
                .MaximumLength(100).WithMessage("length of name must be smaller than 100");
			RuleFor(p => p.Images).Custom((i, ctx) =>
			{
				if (i!=null&&i.Count==0)
				{
					ctx.AddFailure("Image is required");
				}
			});
        }
	}
}


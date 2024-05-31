using System;
using FluentValidation;
using Lab10_FrontToBack.ViewModels.TagVM;

namespace Lab10_FrontToBack.Validators.TagValidator
{
	public class PostTagValidator:AbstractValidator<PostTagVM>
	{
		public PostTagValidator()
		{
            RuleFor(t => t.Name)
                .MinimumLength(5).WithMessage("length of name must be greater than 5")
                .MaximumLength(100).WithMessage("length of name must be smaller than 100");
        }
    }
	
}


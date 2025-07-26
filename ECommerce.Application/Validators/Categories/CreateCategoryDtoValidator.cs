using FluentValidation;
using ECommerce.Application.DTOs;

namespace ECommerce.Application.Validators.Categories
{
    public   class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Category name is required")
                .MaximumLength(100).WithMessage("Category name must not exceed 50 characters.");
        }
    }
}

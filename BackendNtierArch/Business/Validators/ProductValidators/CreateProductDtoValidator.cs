using Entities.DTOs.ProductDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validators.ProductValidator
{
    public class CreateProductDtoValidator: AbstractValidator<CreateProductDTO>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required")
                .NotNull().WithMessage("Can not be empty").MaximumLength(100).WithMessage("Name size can be maximum 100");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Descrption is required")
                    .NotNull().WithMessage("Can not be empty").MaximumLength(500).WithMessage("Description size can be maximum 500");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Price is required").NotNull().WithMessage("Can not be empty");
        }

    }
}

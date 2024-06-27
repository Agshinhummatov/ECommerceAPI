using E_CommerceAPI.Application.Consts;
using E_CommerceAPI.Application.DTOs.Product;
using E_CommerceAPI.Application.Features.Commands.Product.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceAPI.Application.Validations.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductValidator()
        {
           


            RuleFor(p => p.Name)
           .NotEmpty().WithMessage(ResponseMessages.BlankProductName)
           .MaximumLength(150).MinimumLength(2).WithMessage(ResponseMessages.InvalidProductNameLength);

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage(ResponseMessages.BlankProductDescription)
                .MaximumLength(1000).MinimumLength(2).WithMessage(ResponseMessages.InvalidProductDescriptionLength);

            RuleFor(p => p.Stock)
                .NotEmpty().WithMessage(ResponseMessages.BlankStock)
                .Must(p => p >= 0).WithMessage(ResponseMessages.NegativeStock)
                .LessThanOrEqualTo(int.MaxValue).WithMessage(ResponseMessages.ExcessiveStock);

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage(ResponseMessages.BlankPrice)
                .GreaterThan(0).WithMessage(ResponseMessages.NegativePrice)
                .NotEqual(0).WithMessage(ResponseMessages.ZeroPrice)
                .LessThanOrEqualTo(decimal.MaxValue).WithMessage(ResponseMessages.ExcessivePrice);

        }
    }

}

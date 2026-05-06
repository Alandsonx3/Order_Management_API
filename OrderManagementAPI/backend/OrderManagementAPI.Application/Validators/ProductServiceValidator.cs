using FluentValidation;
using OrderManagementAPI.Application.DTOs;

namespace OrderManagementAPI.Application.Validators
{
    public class ProductServiceValidator : AbstractValidator<ProductDTO>
    {
        public ProductServiceValidator ()
        {
            RuleFor(p => p.Description).NotNull().WithMessage("Descrição não pode ser vazia");
            RuleFor(p => p.Category).NotNull().WithMessage("Descrição não pode ser vazia");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Preço deve ser maior que zero");
            RuleFor(p => p.Quantify).GreaterThan(0).WithMessage("Quantidade deve ser maior que zero");
        }
    }
}

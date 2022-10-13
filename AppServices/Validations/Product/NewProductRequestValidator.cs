using AppServices.Mappers.CustomerBankInfo.Requests;
using AppServices.Mappers.Product.Requests;
using DomainModels;
using FluentValidation;
using System;

namespace AppServices.Validations.Product
{
    public class NewProductRequestValidator : AbstractValidator<NewProductRequest>
    {
        public NewProductRequestValidator()
        {
            RuleFor(x => x.Symbol)
                .NotEmpty()
                .WithMessage("Necessário especificar o Símbolo do produto");

            RuleFor(x => x.IssuanceAt)
                .NotEmpty()
                .WithMessage("Necessário especificar a data de emissão");

            RuleFor(x => x.ExpirationAt)
                .NotEmpty()
                .WithMessage("Necessário especificar a data de vencimento");

            RuleFor(x => x.Type)
                .NotEmpty()
                .WithMessage("Necessário especificar o tipo do produto")
                .Must(type => Enum.IsDefined(typeof(ProductType), type))
                .WithMessage("Especifique um tipo de produto válido");
        }
    }
}

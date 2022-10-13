using AppServices.Mappers.Portfolio.Requests;
using FluentValidation;
using System;

namespace AppServices.Validations.Portfolio
{
    public class InvestmentRequestValidator : AbstractValidator<InvestmentRequest>
    {
        public InvestmentRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty()
                .WithMessage("Necessário especificar o produto a ser investido");

            RuleFor(x => x.PortfolioId)
                .NotEmpty()
                .WithMessage("Necessário especificar a carteira a ser investida");

            RuleFor(x => x.Quotes)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Necessário especificar uma quantidade válida");

            RuleFor(x => x.UnitPrice)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Necessário especificar um PU válido");

            RuleFor(x => x.LiquidatedAt)
                .NotEmpty()
                .WithMessage("Necessário especificar uma data de liquidação")
                .Must(liquidatedAt => liquidatedAt >= DateTime.Now)
                .WithMessage("Data de liquidação da ordem deve ser maior ou igual ao dia de hoje");
        }
    }
}

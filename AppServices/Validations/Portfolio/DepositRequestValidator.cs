using AppServices.Mappers.Portfolio.Requests;
using FluentValidation;

namespace AppServices.Validations.Portfolio
{
    public class DepositRequestValidator : AbstractValidator<DepositRequest>
    {
        public DepositRequestValidator()
        {
            RuleFor(x => x.PortfolioId)
                .NotEmpty()
                .WithMessage("Necessário especificar a carteira");

            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Necessário especificar o usuário");

            RuleFor(x => x.Amount)
                .NotEmpty()
                .WithMessage("Necessário especificar o valor do depósito")
                .GreaterThan(0)
                .WithMessage("O valor do depósito deve ser maior que 0");
        }
    }
}

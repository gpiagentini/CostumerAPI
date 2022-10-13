using AppServices.Mappers.Portfolio.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Validations.Portfolio
{
    public class CreateNewPortfolioValidator : AbstractValidator<CreateNewPortfolioRequest>
    {
        public CreateNewPortfolioValidator() {
            RuleFor(portfolio => portfolio.Name)
                .NotEmpty()
                .WithMessage("Porfólio necessita de um nome")
                .MaximumLength(100)
                .WithMessage("O nome deve conter menos de 100 caracteres");

            RuleFor(porfolio => porfolio.CustomerId)
                .NotEmpty()
                .WithMessage("Necessário especificar o id do usuário");

            RuleFor(portfolio => portfolio.Description)
                .MaximumLength(150)
                .WithMessage("Descrição deve conter menos de 150 caracteres");
        }
    }
}

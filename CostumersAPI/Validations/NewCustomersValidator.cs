using FluentValidation;
using CostumersAPI.Costumer;

namespace CostumersAPI.Validations
{
    public class NewCustomersValidator : AbstractValidator<CostumerBase>
    {
        public NewCustomersValidator()
        {
            RuleFor(costumer => costumer.FullName).NotEmpty().WithMessage("Favor especificar o campo \"Nome completo\"");
            RuleFor(costumer => costumer.Email).NotEmpty().WithMessage("Favor especificar o campo \"Email\"");
            RuleFor(costumer => costumer.Email).EmailAddress().WithMessage("Favor informar um Email válido");
            RuleFor(costumer => costumer.Cpf).NotEmpty().WithMessage("Favor especificar o campo \"Cpf\"");
            RuleFor(costumer => costumer.Cellphone).NotEmpty().WithMessage("Favor especificar o campo \"Celular\"");
            RuleFor(costumer => costumer.Birthdate).NotEmpty().WithMessage("Favor especificar o campo \"Data de Nascimento\"");
            RuleFor(costumer => costumer.EmailSms).NotEmpty().WithMessage("Favor especificar o campo \"Email e SMS\"");
            RuleFor(costumer => costumer.Whatsapp).NotEmpty().WithMessage("Favor especificar o campo \"Whatsapp\"");
            RuleFor(costumer => costumer.Country).NotEmpty().WithMessage("Favor especificar o campo \"País\"");
            RuleFor(costumer => costumer.City).NotEmpty().WithMessage("Favor especificar o campo \"Cidade\"");
            RuleFor(costumer => costumer.PostalCode).NotEmpty().WithMessage("Favor especificar o campo \"Cep\"");
            RuleFor(costumer => costumer.Address).NotEmpty().WithMessage("Favor especificar o campo \"Endereço\"");
            RuleFor(costumer => costumer.Number).NotEmpty().WithMessage("Favor especificar o campo \"Número\"");
            RuleFor(costumer => costumer.EmailConfirmation).NotEmpty().WithMessage("Favor especificar o campo \"Confirmar Email\"");
            RuleFor(costumer => new { costumer.Email, costumer.EmailConfirmation })
                .Must(costumerEmail => _validateEmailConfirmation(costumerEmail.Email, costumerEmail.EmailConfirmation))
                .WithMessage("Confirmação de Email divergente");

        }

        private bool _validateEmailConfirmation(string email, string emailConfirmation)
        {
            if (email.Equals(emailConfirmation))
                return true;
            return false;
        }
    }
}

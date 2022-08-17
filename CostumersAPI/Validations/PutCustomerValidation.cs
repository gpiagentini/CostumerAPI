using CostumersAPI.Costumer;
using FluentValidation;
using FluentValidation.Validators;
using CostumersAPI.CustomExtensions;

namespace CostumersAPI.Validations
{
    public class PutCustomerValidation : AbstractValidator<CostumerBase>
    {
        public PutCustomerValidation()
        {
            RuleFor(costumer => costumer.FullName)
                .NotEmpty().WithMessage("Favor especificar o campo \"Nome completo\"");
            RuleFor(costumer => costumer.Email)
                .NotEmpty().EmailAddress(EmailValidationMode.Net4xRegex)
                .WithMessage("Favor especificar o campo \"Email\" válido");
            RuleFor(costumer => costumer.Cpf)
                .NotEmpty().WithMessage("Favor especificar o campo \"Cpf\"")
                .Must(cpf => cpf.IsValidCPF()).WithMessage("Cpf especificado não é válido");
            RuleFor(costumer => costumer.Cellphone)
                .NotEmpty().WithMessage("Favor especificar o campo \"Celular\"")
                .Must(cellphone => cellphone.IsValidCellphone()).WithMessage("Celular especificado é inválido");
            RuleFor(costumer => costumer.Birthdate)
                .NotEmpty().WithMessage("Favor especificar o campo \"Data de Nascimento\"")
                .Must(birthdate => birthdate.GetAge() >= 18).WithMessage("Necessário ter mais de 18 anos");
            RuleFor(costumer => costumer.EmailSms)
                .NotEmpty().WithMessage("Favor especificar o campo \"Email e SMS\"");
            RuleFor(costumer => costumer.Whatsapp)
                .NotEmpty().WithMessage("Favor especificar o campo \"Whatsapp\"");
            RuleFor(costumer => costumer.Country)
                .NotEmpty().WithMessage("Favor especificar o campo \"País\"");
            RuleFor(costumer => costumer.City)
                .NotEmpty().WithMessage("Favor especificar o campo \"Cidade\"");
            RuleFor(costumer => costumer.PostalCode)
                .NotEmpty().WithMessage("Favor especificar o campo \"Cep\"");
            RuleFor(costumer => costumer.Address)
                .NotEmpty().WithMessage("Favor especificar o campo \"Endereço\"");
            RuleFor(costumer => costumer.Number)
                .NotEmpty().WithMessage("Favor especificar o campo \"Número\"");
        }
    }
}

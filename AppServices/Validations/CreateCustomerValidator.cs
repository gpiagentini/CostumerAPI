﻿using FluentValidation;
using FluentValidation.Validators;
using AppServices.CustomExtensions;
using AppServices.Mappers.Customer;

namespace AppServices.Validations
{
<<<<<<<< HEAD:AppServices/Validations/CreateCustomerValidator.cs
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
========
    public class NewCustomerValidator : AbstractValidator<CustomerBase>
    {
        public NewCustomerValidator()
>>>>>>>> main:AppServices/Validations/NewCustomerValidator.cs
        {
            RuleFor(costumer => costumer.FullName)
                .NotEmpty().WithMessage("Favor especificar o campo \"Nome completo\"");

            RuleFor(costumer => costumer.Email)
                .NotEmpty().WithMessage("Favor especificar o campo \"Email\"")
                .EmailAddress(EmailValidationMode.Net4xRegex).WithMessage("Favor especificar em e-mail válido");

            RuleFor(costumer => costumer.Cpf)
                .NotEmpty().WithMessage("Favor especificar o campo \"Cpf\"")
                .Must(cpf => cpf.IsValidCPF()).WithMessage("Cpf especificado não é válido");

            RuleFor(costumer => costumer.Cellphone)
                .NotEmpty().WithMessage("Favor especificar o campo \"Celular\"")
                .Must(cellphone => cellphone.IsValidCellphone()).WithMessage("Celular informado é inválido");

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
                .NotEmpty().WithMessage("Favor especificar o campo \"Cep\"")
                .Must(postalCode => postalCode.IsValidPostalCode()).WithMessage("Cep informado é inválido");

            RuleFor(costumer => costumer.Address)
                .NotEmpty().WithMessage("Favor especificar o campo \"Endereço\"");

            RuleFor(costumer => costumer.Number)
                .NotEmpty().WithMessage("Favor especificar o campo \"Número\"");

            RuleFor(costumer => costumer)
<<<<<<<< HEAD:AppServices/Validations/CreateCustomerValidator.cs
========
                .NotEmpty().WithMessage("Favor informar a validação do E-mail")
>>>>>>>> main:AppServices/Validations/NewCustomerValidator.cs
                .Must(costumer => costumer.EmailConfirmation.Equals(costumer.Email)).WithMessage("Confirmação de Email divergente");
        }
    }
}

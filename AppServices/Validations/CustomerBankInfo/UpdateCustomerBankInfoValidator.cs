using AppServices.Mappers.CustomerBankInfo.Requests;
using FluentValidation;
using System;

namespace AppServices.Validations.CustomerBankInfo
{
    public class UpdateCustomerBankInfoValidator : AbstractValidator<UpdateCustomerBankInfoRequest>
    {
        public UpdateCustomerBankInfoValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("Necessário especificar o valor a ser depositado/sacado")
                .Must(value => value > 0)
                .WithMessage("Valor precisa ser maior que 0");

            RuleFor(x => x.RequestType)
                .NotEmpty()
                .WithMessage("Necessário especificar o tipo de requisição")
                .Must(requestType => Enum.IsDefined(typeof(AccountRequestType), requestType))
                .WithMessage("Especificar um tipo de requisição válido");
        }
    }
}

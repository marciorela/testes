using FluentValidation;
using Modelo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("Is necessary to inform CPF.")
                .NotNull().WithMessage("Is necessary to inform CPF.");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the birth date.")
                .NotNull().WithMessage("Is necessary to inform the birth date.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Is necessary to inform the birth name.")
                .NotNull().WithMessage("Is necessary to inform the birth name.");

        }

    }
}

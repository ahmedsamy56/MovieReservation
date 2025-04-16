using FluentValidation;
using MovieReservation.Core.Features.Emails.Commands.Models;

namespace MovieReservation.Core.Features.Emails.Commands.Validatiors
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Fields

        #endregion
        #region Constructors
        public SendEmailValidator()
        {
            ApplyValidationsRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email is required");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message must not be empty")
                .NotNull().WithMessage("Message is required");
        }

        #endregion
    }
}

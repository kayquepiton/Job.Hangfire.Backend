using FluentValidation;
using Job.Hangfire.Backend.Application.Models.Request;

namespace Job.Hangfire.Backend.Application.Validators;

public class EmailRequestValidator : AbstractValidator<EmailRequest>
{
    public EmailRequestValidator()
    {
        RuleFor(x => x.Recipient)
            .NotEmpty().WithMessage("O destinatário é obrigatório.")
            .EmailAddress().WithMessage("Endereço de e-mail inválido.")
            .MaximumLength(255).WithMessage("O destinatário não pode exceder 255 caracteres.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("O assunto é obrigatório.")
            .MaximumLength(255).WithMessage("O assunto não pode exceder 255 caracteres.");

        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("O corpo do e-mail é obrigatório.");
    }
}

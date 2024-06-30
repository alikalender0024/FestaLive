using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    internal class TicketValidator : AbstractValidator<Ticket>
    {
        public TicketValidator()
        {
            RuleFor(ticket => ticket.FullName)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.");

            RuleFor(ticket => ticket.FullName)
                .MaximumLength(100).WithMessage("Ad soyad en fazla 100 karakter olabilir.");

            RuleFor(ticket => ticket.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.");

            RuleFor(ticket => ticket.Email)
                .MaximumLength(100).WithMessage("E-posta en fazla 100 karakter olabilir.");

            RuleFor(ticket => ticket.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(ticket => ticket.Phone)
                .NotEmpty().WithMessage("Telefon boş olamaz.");

            RuleFor(ticket => ticket.Phone)
                .MaximumLength(20).WithMessage("Telefon en fazla 20 karakter olabilir.");

            RuleFor(ticket => ticket.TicketType)
                .NotEmpty().WithMessage("Bilet tipi boş olamaz.");

            RuleFor(ticket => ticket.TicketType)
                .MaximumLength(50).WithMessage("Bilet tipi en fazla 50 karakter olabilir.");

            RuleFor(ticket => ticket.NumberOfTickets)
                .NotEmpty().WithMessage("Bilet sayısı boş olamaz.");

            RuleFor(ticket => ticket.NumberOfTickets)
                .GreaterThan(0).WithMessage("Bilet sayısı 0'dan büyük olmalıdır.");

            RuleFor(ticket => ticket.AdditionalRequest)
                .MaximumLength(500).WithMessage("Ek talepler en fazla 500 karakter olabilir.");
        }
    }
}

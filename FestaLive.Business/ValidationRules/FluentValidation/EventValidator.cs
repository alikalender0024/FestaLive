using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    public class EventValidator : AbstractValidator<Event>
    {
        public EventValidator()
        {
            RuleFor(eventItem => eventItem.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            RuleFor(eventItem => eventItem.Title)
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(eventItem => eventItem.Time)
                .NotEmpty().WithMessage("Saat boş olamaz.");

            RuleFor(eventItem => eventItem.Time)
                .MaximumLength(50).WithMessage("Saat en fazla 50 karakter olabilir.");

            RuleFor(eventItem => eventItem.Artist)
                .NotEmpty().WithMessage("Sanatçı boş olamaz.");

            RuleFor(eventItem => eventItem.Artist)
                .MaximumLength(100).WithMessage("Sanatçı en fazla 100 karakter olabilir.");

            RuleFor(eventItem => eventItem.EventDate)
                .NotEmpty().WithMessage("Etkinlik tarihi boş olamaz.");
        }
    }
}

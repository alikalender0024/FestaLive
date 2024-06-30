using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(about => about.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            RuleFor(about => about.Title)
                .Length(2, 100).WithMessage("Başlık 2 ile 100 karakter arasında olmalıdır.");

            RuleFor(about => about.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.");

            RuleFor(about => about.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olmalıdır.");

            RuleFor(about => about.Subtitle)
                .NotEmpty().WithMessage("Alt Başlık boş olamaz.");

            RuleFor(about => about.Subtitle)
                .Length(2, 100).WithMessage("Alt Başlık 2 ile 100 karakter arasında olmalıdır.");

            RuleFor(about => about.PartyDescription)
                .NotEmpty().WithMessage("Parti Açıklama boş olamaz.");

            RuleFor(about => about.PartyDescription)
                .MaximumLength(500).WithMessage("Parti Açıklama en fazla 500 karakter olmalıdır.");

            RuleFor(about => about.IconUrl).NotEmpty();

            RuleFor(about => about.MomentTitle)
                .NotEmpty().WithMessage("Anlık Başlık boş olamaz.");

            RuleFor(about => about.MomentTitle)
                .Length(2, 100).WithMessage("Anlık Başlık 2 ile 100 karakter arasında olmalıdır.");

            RuleFor(about => about.MomentDescription)
                .NotEmpty().WithMessage("Anlık Açıklama boş olamaz.");

            RuleFor(about => about.MomentDescription)
                .MaximumLength(500).WithMessage("Anlık Açıklama en fazla 500 karakter olmalıdır.");
        }
    }
}

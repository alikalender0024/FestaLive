using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    internal class SocialMediaValidator : AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(socialMedia => socialMedia.PlatformName)
                .NotEmpty().WithMessage("Platform adı boş olamaz.");

            RuleFor(socialMedia => socialMedia.PlatformName)
                .MaximumLength(50).WithMessage("Platform adı en fazla 50 karakter olabilir.");

            RuleFor(socialMedia => socialMedia.IconUrl)
                .NotEmpty().WithMessage("İkon URL boş olamaz.");

            RuleFor(socialMedia => socialMedia.IconUrl)
                .MaximumLength(200).WithMessage("İkon URL en fazla 200 karakter olabilir.");

            RuleFor(socialMedia => socialMedia.Url)
                .NotEmpty().WithMessage("URL boş olamaz.");

            RuleFor(socialMedia => socialMedia.Url)
                .MaximumLength(200).WithMessage("URL en fazla 200 karakter olabilir.");
        }
    }
}

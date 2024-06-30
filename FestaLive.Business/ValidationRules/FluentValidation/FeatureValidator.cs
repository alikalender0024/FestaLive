using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    internal class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(feature => feature.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            RuleFor(feature => feature.Title)
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(feature => feature.Subtitle)
            .NotEmpty().WithMessage("Alt Başlık boş olamaz.");

            RuleFor(feature => feature.Subtitle)
                .MaximumLength(200).WithMessage("Alt Başlık en fazla 200 karakter olabilir.");

            RuleFor(feature => feature.StartDate)
                .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");

            RuleFor(feature => feature.EndDate)
                .NotEmpty().WithMessage("Bitiş tarihi boş olamaz");

            RuleFor(feature => feature.EndDate)
                .GreaterThanOrEqualTo(feature => feature.StartDate)
                .WithMessage("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");

            RuleFor(feature => feature.Location)
                .MaximumLength(200).WithMessage("Konum en fazla 200 karakter olabilir.");

            RuleFor(feature => feature.ImageUrl)
                .NotEmpty().WithMessage("Resim URL boş olamaz.");

            RuleFor(feature => feature.ImageUrl)
                .MaximumLength(200).WithMessage("Resim URL en fazla 200 karakter olabilir.");
        }
    }
}

using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    internal class PlanValidator : AbstractValidator<Plan>
    {
        public PlanValidator()
        {
            RuleFor(plan => plan.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.");

            RuleFor(plan => plan.Title)
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(plan => plan.Price)
                .NotEmpty().WithMessage("Fiyat boş olamaz.");

            RuleFor(plan => plan.Price)
                .GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");

            RuleFor(plan => plan.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.");

            RuleFor(plan => plan.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(plan => plan.DiscountRate)
                .MaximumLength(50).WithMessage("İndirim Oranı en fazla 50 karakter olabilir.");
        }
    }
}

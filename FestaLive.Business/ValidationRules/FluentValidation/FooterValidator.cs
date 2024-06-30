using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    internal class FooterValidator : AbstractValidator<Footer>
    {
        public FooterValidator()
        {
            RuleFor(footer => footer.Phone)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.");

            RuleFor(footer => footer.Phone)
                .MaximumLength(20).WithMessage("Telefon numarası en fazla 20 karakter olabilir.");

            RuleFor(footer => footer.EMail)
                .NotEmpty().WithMessage("E-posta adresi boş olamaz.");

            RuleFor(footer => footer.EMail)
                .MaximumLength(100).WithMessage("E-posta adresi en fazla 100 karakter olabilir.");

            RuleFor(footer => footer.EMail)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(footer => footer.Location)
                .NotEmpty().WithMessage("Konum bilgisi boş olamaz.");

            RuleFor(footer => footer.Location)
                .MaximumLength(200).WithMessage("Konum bilgisi en fazla 200 karakter olabilir.");
        }
    }
}

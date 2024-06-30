using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    public class ContactFormValidator : AbstractValidator<ContactForm>
    {
        public ContactFormValidator()
        {
            RuleFor(contactForm => contactForm.FullName)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.");

            RuleFor(contactForm => contactForm.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.");

            RuleFor(contactForm => contactForm.Email)
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(contactForm => contactForm.Email)
            .MaximumLength(100).WithMessage("E-posta Adresi en fazla 100 karakter olabilir.");

            RuleFor(contactForm => contactForm.Subject)
                .NotEmpty().WithMessage("Konu boş olamaz.");

            RuleFor(contactForm => contactForm.Subject)
            .MaximumLength(200).WithMessage("Konu en fazla 200 karakter olabilir.");


            RuleFor(contactForm => contactForm.Message)
                .NotEmpty().WithMessage("Mesaj boş olamaz.");

            RuleFor(contactForm => contactForm.Message)
            .MaximumLength(500).WithMessage("Mesaj İçeriği en fazla 500 karakter olabilir.");

        }
    }
}

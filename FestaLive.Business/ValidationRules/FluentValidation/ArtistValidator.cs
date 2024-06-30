using FluentValidation;
using FestaLive.Entities.Concrete;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    public class ArtistValidator : AbstractValidator<Artist>
    {
        public ArtistValidator()
        {
            RuleFor(artist => artist.Name)
                .NotEmpty().WithMessage("Sanatçı adı boş olamaz.");

            RuleFor(artist => artist.Name)
                .Length(2, 100).WithMessage("Sanatçı adı 2 ile 100 karakter arasında olmalıdır.");

            RuleFor(artist => artist.Birthdate)
                .NotEmpty().WithMessage("Tarih boş olamaz.");

            RuleFor(artist => artist.MusicGenre)
                .NotEmpty().WithMessage("Tür boş olamaz.");

            RuleFor(artist => artist.MusicGenre)
                .MaximumLength(50).WithMessage("Tür en fazla 50 karakter olmalıdır.");

            RuleFor(artist => artist.ImageUrl)
                .NotEmpty().WithMessage("Resim URL boş olamaz.");

            RuleFor(artist => artist.ImageUrl)
                .MaximumLength(200).WithMessage("Resim URL en fazla 200 karakter olmalıdır.");

            RuleFor(artist => artist.YoutubeChannel)
                .NotEmpty().WithMessage("Youtube Kanal URL boş olamaz.");

            RuleFor(artist => artist.YoutubeChannel)
                .MaximumLength(200).WithMessage("Youtube Kanal en fazla 200 karakter olmalıdır.");
        }

    }
}

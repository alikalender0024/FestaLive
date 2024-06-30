using FestaLive.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestaLive.Business.ValidationRules.FluentValidation
{
    public class CalendarValidator : AbstractValidator<Calendar>
    {
        public CalendarValidator()
        {
            RuleFor(calendar => calendar.EventDate)
                .NotEmpty().WithMessage("Etkinlik tarihi boş olamaz.");
        }
    }
}
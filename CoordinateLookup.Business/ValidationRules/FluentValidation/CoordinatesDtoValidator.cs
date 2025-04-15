using CoordinateLookup.Dto.DTOs;
using FluentValidation;
namespace CoordinateLookup.Business.ValidationRules.FluentValidation
{
    public class CoordinatesDtoValidator: AbstractValidator<CoordinatesDto>
    {
        public CoordinatesDtoValidator()
        {
            RuleFor(x => x.Latitude)
                .NotEmpty().WithMessage("Latitude değeri boş olamaz.")
                .InclusiveBetween(-90, 90).WithMessage("Latitude değeri -90 ile 90 arasında olmalıdır.");
            RuleFor(x => x.Longitude)
                .NotEmpty().WithMessage("Longitude değeri boş olamaz.")
                .InclusiveBetween(-180, 180).WithMessage("Longitude değeri -180 ile 180 arasında olmalıdır.");
        }
    }
}

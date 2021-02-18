using RadioConsole.Web.Models;
using FluentValidation;

namespace RadioConsole.Web.Models.Validators
{
    public class IncidentModelValidator : AbstractValidator<IncidentModel>
    {
        public IncidentModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Latitude).NotEmpty();

            RuleFor(x => x.Longitude).NotEmpty();

            RuleFor(x => x.Group).IsInEnum();
        }
    }
}

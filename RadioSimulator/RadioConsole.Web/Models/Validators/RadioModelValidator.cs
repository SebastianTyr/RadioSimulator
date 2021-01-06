using FluentValidation;

namespace RadioConsole.Web.Models.Validators
{
    public class RadioModelValidator : AbstractValidator<RadioModel>
    {
        public RadioModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty();

            RuleFor(x => x.SerialNumber).NotEmpty();

            RuleFor(x => x.SignalStrength).InclusiveBetween(1, 10);

            RuleFor(x => x.BatteryLevel).InclusiveBetween(10, 100);

            RuleFor(x => x.Type).IsInEnum();

            RuleFor(x => x.Mode).IsInEnum();

            RuleFor(x => x.Unit).IsInEnum();
        }
    }
}

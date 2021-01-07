using FluentValidation;
using LastTask.Models.Request;

namespace LastTask.Validators
{
    public class SmartphoneRequestValidator : AbstractValidator<SmartphoneRequest>
    {
        public SmartphoneRequestValidator()
        {
            RuleFor(x => x.SmartphoneId).GreaterThan(0);
            RuleFor(x => x.SmartphoneBrand).MaximumLength(25);
            RuleFor(x => x.SmartphoneBrand).MinimumLength(5);
            RuleFor(x => x.SmartphoneModel).MaximumLength(25);
            RuleFor(x => x.SmartphoneModel).MaximumLength(5);
            RuleFor(x => x.Inch).MaximumLength(25);
            RuleFor(x => x.Inch).MinimumLength(5);
            RuleFor(x => x.BackCameraMP).MaximumLength(25);
            RuleFor(x => x.BackCameraMP).MinimumLength(5);
            RuleFor(x => x.FrontCameraMP).MaximumLength(25);
            RuleFor(x => x.FrontCameraMP).MinimumLength(5);
            RuleFor(x => x.Memory).MaximumLength(25);
            RuleFor(x => x.Memory).MinimumLength(5);
            RuleFor(x => x.Memory).MaximumLength(25);
            RuleFor(x => x.Memory).MinimumLength(5);
            RuleFor(x => x.BaterymAh).MaximumLength(25);
            RuleFor(x => x.BaterymAh).MinimumLength(5);
        }
    }
}

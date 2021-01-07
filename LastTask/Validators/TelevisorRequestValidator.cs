using FluentValidation;
using LastTask.Models.Request;

namespace LastTask.Validators
{
    public class TelevisorRequestValidator : AbstractValidator<TelevisorRequest>
    {
        public TelevisorRequestValidator()
        {
            RuleFor(x => x.TelevisorId).GreaterThan(0);
            RuleFor(x => x.TelevisorBrand).MaximumLength(25);
            RuleFor(x => x.TelevisorBrand).MinimumLength(5);
            RuleFor(x => x.TelevisorModel).MaximumLength(25);
            RuleFor(x => x.TelevisorModel).MaximumLength(5);
            RuleFor(x => x.Inch).MaximumLength(25);
            RuleFor(x => x.Inch).MinimumLength(5);
            RuleFor(x => x.TelevisorCategory).MaximumLength(25);
            RuleFor(x => x.TelevisorCategory).MinimumLength(5);
            RuleFor(x => x.Resolution).MaximumLength(25);
            RuleFor(x => x.Resolution).MinimumLength(5);
        }
    }
}

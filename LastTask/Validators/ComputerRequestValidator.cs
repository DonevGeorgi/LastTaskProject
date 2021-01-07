using FluentValidation;
using LastTask.Models.Request;

namespace LastTask.Validators
{
    public class ComputerRequestValidator : AbstractValidator<ComputerRequest>
    {
        public ComputerRequestValidator()
        {
            RuleFor(x => x.ComputerId).GreaterThan(0);
            RuleFor(x => x.ComputerBrand).MaximumLength(25);
            RuleFor(x => x.ComputerBrand).MinimumLength(5);
            RuleFor(x => x.ComputerModel).MaximumLength(25);
            RuleFor(x => x.ComputerModel).MaximumLength(5);
            RuleFor(x => x.GraphicCard).MaximumLength(25);
            RuleFor(x => x.GraphicCard).MinimumLength(5);
            RuleFor(x => x.RAM).GreaterThan(0);
            RuleFor(x => x.Motherboard).MaximumLength(25);
            RuleFor(x => x.Motherboard).MinimumLength(5);
            RuleFor(x => x.PowerSupply).MaximumLength(25);
            RuleFor(x => x.PowerSupply).MinimumLength(5);
            RuleFor(x => x.Memory).MaximumLength(25);
            RuleFor(x => x.Memory).MinimumLength(5);
            RuleFor(x => x.ComputerCase).MaximumLength(25);
            RuleFor(x => x.ComputerCase).MinimumLength(5);
        }
    }
}

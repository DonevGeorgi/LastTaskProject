using FluentValidation;
using LastTask.Models.Request;

namespace LastTask.Validators
{
    public class LaptopRequestValidator : AbstractValidator<LaptopRequest>
    {
        public LaptopRequestValidator()
        {
            RuleFor(x => x.LaptopId).GreaterThan(0);
            RuleFor(x => x.LaptopBrand).MaximumLength(25);
            RuleFor(x => x.LaptopBrand).MinimumLength(5);
            RuleFor(x => x.LaptopModel).MaximumLength(25);
            RuleFor(x => x.LaptopModel).MaximumLength(5);
            RuleFor(x => x.GraphicCard).MaximumLength(25);
            RuleFor(x => x.GraphicCard).MinimumLength(5);
            RuleFor(x => x.RAM).GreaterThan(0);
            RuleFor(x => x.Motherboard).MaximumLength(25);
            RuleFor(x => x.Motherboard).MinimumLength(5);
            RuleFor(x => x.PowerSupply).MaximumLength(25);
            RuleFor(x => x.PowerSupply).MinimumLength(5);
            RuleFor(x => x.Memory).MaximumLength(25);
            RuleFor(x => x.Memory).MinimumLength(5);
            RuleFor(x => x.Battery).MaximumLength(25);
            RuleFor(x => x.Battery).MinimumLength(5);
        }
    }
}

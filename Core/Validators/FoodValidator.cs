namespace Core.Validators;

public interface IFoodInventoryValidator : IValidator<FoodDto>
{
}

public class FoodValidator : AbstractValidator<FoodDto>, IFoodInventoryValidator
{
    public FoodValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.Name).Length(1, 75);
        RuleFor(x => x.Measurement).GreaterThanOrEqualTo(0);
        RuleFor(x => x.MeasurementTypeId).IsInEnum();
        RuleFor(x => x.DepartmentId).IsInEnum();
    }
}

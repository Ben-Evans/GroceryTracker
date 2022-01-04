namespace Core.Validators;

public interface IFoodValidator : IValidator<FoodDto>
{
}

public class FoodValidator : AbstractValidator<FoodDto>, IFoodValidator
{
    public FoodValidator()
    {
        RuleFor(x => x).NotNull();
        RuleFor(x => x.Name).NotNull().Length(2, 100);
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
        RuleFor(x => x.QuantitiyToAddWhenDisposed).GreaterThanOrEqualTo(0);
        // RuleFor(x => x.Url).LessThanOrEqualTo(100).Unless(x => x == null); // TODO: Need to workaround nullable strings
        RuleFor(x => x.Measurement).GreaterThan(0);
        RuleFor(x => x.MeasurementType).IsInEnumeration();
        RuleFor(x => x.ToDelete).NotEqual(true).When(x => !x.IsSaved()).WithMessage("Cannot delete unsaved values.");
        RuleFor(x => x.ExpiryDate).GreaterThanOrEqualTo(DateTime.Today).WithMessage("Expiry date cannot be older than today.");
    }
}

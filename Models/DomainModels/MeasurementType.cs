namespace Models.DomainModels;

/// <summary>
/// Item, Litre, Milliliter, Pound, Gram
/// </summary>
public class MeasurementType : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

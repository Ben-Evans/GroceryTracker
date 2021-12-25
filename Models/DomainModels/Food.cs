namespace Models.DomainModels;

public class Food : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double? Measurement { get; set; }
    public MeasurementType? MeasurementType { get; set; }
    public int? MeasurementTypeId { get; set; }
    public Department? Department { get; set; }
    public int? DepartmentId { get; set; }
    public Brand? PreferredBrand { get; set; }
    public int? PreferredBrandId { get; set; }
    public Store? PreferredStore { get; set; }
    public int? PreferredStoreId { get; set; }
}

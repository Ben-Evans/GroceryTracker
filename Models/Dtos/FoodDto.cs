namespace Models.Dtos;

public class FoodDto : IHasId, IDeletable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double? Measurement { get; set; }
    public MeasurementTypeId? MeasurementTypeId { get; set; }
    public DepartmentTypeId? DepartmentId { get; set; }
    public int? PreferredBrandId { get; set; }
    public int? PreferredStoreId { get; set; }
    public bool Delete { get; set; } = false;
}

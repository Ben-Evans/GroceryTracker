namespace Models.Dtos;

public class FoodDto : IHasId, IDeletable
{
    public FoodDto(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int QuantitiyToAddWhenDisposed { get; set; }
    public string? Url { get; set; }
    public string? Barcode { get; set; }
    public int ProductTypeId { get; set; }
    public int? BrandId { get; set; }
    public int? StoreId { get; set; }
    public DateTime? ExpiryDate { get; set; } // TODO: Switch to DateOnly? when SQL/EF supports it
    public double? Measurement { get; set; }
    public MeasurementTypeEnum? MeasurementType { get; set; }
    public int? GroceryDepartmentId { get; set; }
    public bool? IsRefrigerated { get; set; }
    public bool ToDelete { get; set; } = false;
}

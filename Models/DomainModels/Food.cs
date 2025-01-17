﻿
namespace Models.DomainModels;

public class Food : Product
{
    public Food(
        string name,
        // ProductType productType, // TODO: Reevaluate
        int quantity = 1,
        int quantityToAddWhenDisposed = 0)
        : base(name, quantity, quantityToAddWhenDisposed)
    {

    }

    [Precision(0)]
    public DateTime? ExpiryDate { get; set; } // TODO: Switch to DateOnly? when SQL/EF supports it

    public bool? IsRefrigerated { get; set; }

    public double? Measurement { get; set; }
    
    public MeasurementType? MeasurementType { get; set; }
    public int? MeasurementTypeId { get; set; }
    
    public GroceryDepartment? GroceryDepartment { get; set; }
    public int? GroceryDepartmentId { get; set; }

    /*[NotMapped]
    public double? MeasurementValue => ProductValue.SafeDivide(Measurement);*/
}

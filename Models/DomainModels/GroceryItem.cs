﻿namespace Models.DomainModels;

public class GroceryItem : ShoppingItem
{
    public GroceryItem(
        string name,
        // ProductType productType, // TODO: Reevaluate
        bool isPurchased,
        bool allowSubstitutions,
        ShoppingList shoppingList,
        int quantity = 1,
        int quantityToAddWhenDisposed = 0)
        : base(name, isPurchased, allowSubstitutions, shoppingList, quantity, quantityToAddWhenDisposed)
    {
    }

    [Precision(0)]
    public DateTime? ExpiryDate { get; set; } // TODO: Switch to DateOnly? when SQL/EF supports it

    public double? Measurement { get; set; }

    public MeasurementType? MeasurementType { get; set; }
    public int? MeasurementTypeId { get; set; }

    public GroceryDepartment? GroceryDepartment { get; set; }
    public int? GroceryDepartmentId { get; set; }

    public bool? IsRefrigerated { get; set; }
}

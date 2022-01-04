namespace Models.DomainModels;

public class Product : INamedDomainModel
{
    public Product(
        string name,
        // ProductType productType, // TODO: Reevaluate
        int quantity = 1,
        int quantityToAddWhenDisposed = 0)
    {
        Name = name;
        // ProductType = productType; // TODO: Reevaluate
        Quantity = quantity;
        QuantityToAddWhenDisposed = quantityToAddWhenDisposed;
    }

    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; }

    public int Quantity { get; set; }

    public int QuantityToAddWhenDisposed { get; set; }

    [MaxLength(150)]
    public string? Url { get; set; }

    [MaxLength(13)]
    public string? Bardcode { get; set; }

    // TODO: Reevaluate
    /*public ProductType ProductType { get; set; }
    public int ProductTypeId { get; set; }*/

    public Brand? Brand { get; set; }
    public int? BrandId { get; set; }

    public Store? Store { get; set; }
    public int? StoreId { get; set; }

    /*public IList<ProductPurchaseHistory> PurchaseHistories { get; set; } = new List<ProductPurchaseHistory>();

    [NotMapped]
    public double? ProductValue => PurchaseHistories.Average(x => (x.PurchasePrice as double?).SafeDivide(Quantity));*/
}

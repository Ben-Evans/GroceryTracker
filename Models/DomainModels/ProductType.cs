namespace Models.DomainModels;

/// <summary>
/// Tech, Grocery, Entertainment, Transportation, House, Utilies, Insurance, Medical/Health, Clothes, Furniture, Recreation ...
/// </summary>
public class ProductType : INamedDomainModel
{
    public ProductType(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }

    public IList<Product> Products { get; set; } = new List<Product>();
}

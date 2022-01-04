namespace Models.DomainModels;

public class Brand : INamedDomainModel
{
    public Brand(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public IList<Store> AvailableStores { get; set; } = new List<Store>();
    
    public IList<Product> Products { get; set; } = new List<Product>();
}

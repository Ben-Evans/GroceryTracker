namespace Models.DomainModels;

public class Store : INamedDomainModel
{
    public Store(int id, string name, string url)
    {
        Id = id;
        Name = name;
        Url = url;
    }

    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    [MaxLength(100)]
    public string Url { get; set; }
    
    public IList<Brand> AvailableBrands { get; set; } = new List<Brand>();

    public IList<Product> Products { get; set; } = new List<Product>();
}

namespace Models.DomainModels;

public class Brand : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Store> AvailableStores { get; set; }
}

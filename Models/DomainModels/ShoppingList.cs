namespace Models.DomainModels;

public class ShoppingList : INamedDomainModel
{
    public ShoppingList(string name)
    {
        Name = name;
    }

    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    public IList<ShoppingItem> ShoppingItems { get; set; } = new List<ShoppingItem>();
}

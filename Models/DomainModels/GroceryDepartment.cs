namespace Models.DomainModels;

public class GroceryDepartment : INamedDomainModel
{
    public GroceryDepartment(int id, string name, bool productsMostlyRefrigerated)
    {
        Id = id;
        Name = name;
        ProductsMostlyRefrigerated = productsMostlyRefrigerated;
    }

    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    public bool ProductsMostlyRefrigerated { get; set; }
}

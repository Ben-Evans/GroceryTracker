namespace Models.DomainModels;

public class Food : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Brand PreferedBrand { get; set; }
    public int PreferedBrandId { get; set; }
    public int Quantity { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public Store StorePreference { get; set; }
}

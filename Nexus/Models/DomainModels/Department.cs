namespace Models.DomainModels;

/// <summary>
/// Bakery, Freezer, Baking, Produce, Dairy, Meat, Toiletries, Personal Care (shampoo, deodorant), Home Improvement (reno stuff, pillow) 
/// </summary>
public class Department : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public PreservationType PreservationType { get; set; }
    public int PreservationTypeId { get; set; }
}

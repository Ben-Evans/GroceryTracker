namespace Models.DomainModels;

/// <summary>
/// Pantry, fridge, freezer
/// </summary>
public class PreservationType : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
}

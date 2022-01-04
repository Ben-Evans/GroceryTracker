namespace Models.Interfaces;

public interface INamedDomainModel : IDomainModel
{
    public string Name { get; set; }
}

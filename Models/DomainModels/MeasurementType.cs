namespace Models.DomainModels;

public class MeasurementType : INamedDomainModel
{
    public MeasurementType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }
}

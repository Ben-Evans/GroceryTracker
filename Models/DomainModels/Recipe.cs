namespace Models.DomainModels;

public class Recipe : INamedDomainModel
{
    public Recipe(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
    
    public int? CookTimeMinutes { get; set; }
    
    [MaxLength(50)]
    public string? SourceName { get; set; }
    
    [MaxLength(150)]
    public string? SourceUrl { get; set; }
    
    [MaxLength(75)]
    public string? ServerImagePath { get; set; }
    
    public IList<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public IList<RecipeStep> RecipeSteps { get; set; } = new List<RecipeStep>();
}

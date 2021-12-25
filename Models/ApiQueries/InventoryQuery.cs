namespace Models.ApiQueries;

public class InventoryQuery
{
    private string? _name;
    public int Skip { get; init; } = 0;
    public int Take { get; init; } = 10;
    public string? SortOrder { get; init; }
    public string? Name
    {
        get => _name;
        init => _name = value?.Trim()?.ToLower();
    }
}

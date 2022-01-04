namespace Models.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Food, FoodDto>();
    }
}

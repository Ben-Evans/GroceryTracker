namespace Core.Services;

public interface IFoodInventoryService
{
    Task<IList<FoodDto>> GetFoods(FoodQuery query);
    Task<FoodDto> GetFood(int id);
    Task<int> CreateOrUpdateFood(FoodDto food);
}

public class FoodInventoryService : IFoodInventoryService
{
    private readonly IFoodInventoryRepository _repository;
    private readonly IFoodValidator _validator;
    private readonly IMapper _mapper;

    public FoodInventoryService(
        IFoodInventoryRepository repository,
        IFoodValidator validator,
        IMapper mapper)
    {
        _repository = repository;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<IList<FoodDto>> GetFoods(FoodQuery query)
    {
        if (query == null) throw new ArgumentNullException(nameof(query));

        var queryable = _repository.GetModels();
        if (!string.IsNullOrWhiteSpace(query.Name)) queryable.Where(x => x.Name.ToLower().Contains(query.Name));

        queryable = (query.SortOrder) switch
        {
            _ => queryable.OrderBy(x => x.Name)
        };

        queryable = queryable.Skip(query.Skip).Take(query.Take);

        var models = await queryable.ToListAsync();

        var dtos = _mapper.Map<IList<FoodDto>>(models);
        return dtos;
    }

    public async Task<FoodDto> GetFood(int id)
    {
        if (id < 1) throw new ArgumentException("Id must be greater than 0.");

        var model = await _repository.GetModel(id);
        if (model == null) throw new ArgumentOutOfRangeException(nameof(id), id, "Could not find a model with this Id.");

        var dto = _mapper.Map<FoodDto>(model);
        return dto;
    }

    public FoodDto InitNewFood()
    {
        var newFood = new Food(string.Empty);

        var dto = _mapper.Map<FoodDto>(newFood);
        return dto;
    }

    public async Task<int> CreateOrUpdateFood(FoodDto food)
    {
        var validationResult = await _validator.ValidateAsync(food);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var saved = await _repository.GetModel(food.Id, true);
        var updatedSaved = CreateUpdateOrDeleteFoodAsync(saved, food);
        
        var updatedEntries = updatedSaved != null ? new Food[] { updatedSaved } : Array.Empty<Food>();
        var saveSuccess = await _repository.Save(updatedEntries);
        
        return saveSuccess && updatedSaved != null ? updatedSaved.Id : default;
    }

    public async Task<bool> DeleteFood(params FoodDto[] foods)
    {
        var validFoodIds = foods.Where(x => x.IsSaved()).Select(x => x.Id);
        if (validFoodIds.Any())
        {
            var savedModels = await _repository.GetModels()
                .Where(x => validFoodIds.Contains(x.Id))
                .ToListAsync();
            _repository.Delete(savedModels.ToArray());
            return true;
        }

        return false;
    }

    private Food? CreateUpdateOrDeleteFoodAsync(Food? saved, FoodDto updated)
    {
        Food CreateFood(FoodDto updated)
        {
            var @new = new Food(string.Empty);
            return UpdateFood(@new, updated);
        }

        Food UpdateFood(Food saved, FoodDto updated)
        {
            saved.Name = updated.Name;
            saved.Quantity = updated.Quantity;
            saved.ExpiryDate = updated.ExpiryDate;
            saved.IsRefrigerated = updated.IsRefrigerated;
            saved.Measurement = updated.Measurement;
            saved.MeasurementTypeId = updated.MeasurementType?.Id;
            saved.GroceryDepartmentId = updated.GroceryDepartmentId;
            saved.BrandId = updated.BrandId;
            saved.StoreId = updated.StoreId;
            return saved;
        }

        Food? Delete(Food saved)
        {
            _repository.Delete(saved);
            return null;
        }

        if (saved != null && updated.ToDelete) return Delete(saved);
        else if (saved == null && updated != null) return CreateFood(updated);
        else if (saved != null && updated != null) return UpdateFood(saved, updated);
        else throw new SystemException("Unexpected values found!");
    }

    public static FoodDto ConvertToDto(Food food)
    {
        throw new NotImplementedException();
    }

    public static IList<FoodDto> ConvertToDto(IList<Food> foods)
    {
        return foods.Select(ConvertToDto).ToList();
    }
}

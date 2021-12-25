using Microsoft.EntityFrameworkCore;

namespace Core.Services;

public interface IFoodInventoryService
{
    Task<IList<Food>> GetFoodInventory(InventoryQuery query);
    Task<Food> GetFood(int id);
    Task<bool> UpdateFood(FoodDto food);
}

public class FoodInventoryService : IFoodInventoryService
{
    private IFoodInventoryRepository _repository;
    private IFoodInventoryValidator _validator;

    public FoodInventoryService(IFoodInventoryRepository repository, IFoodInventoryValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public Task<Food> GetFood(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IList<Food>> GetFoodInventory(InventoryQuery query)
    {
        var queryable = await _repository.GetFoodInventory();
        if (!string.IsNullOrWhiteSpace(query.Name)) queryable.Where(x => x.Name.ToLower() == query.Name);

        queryable = (query.SortOrder) switch
        {
            _ => queryable.OrderBy(x => x.Name)
        };

        queryable = queryable.Skip(query.Skip).Take(query.Take);

        return await queryable.ToListAsync();
    }

    public async Task<bool> UpdateFood(FoodDto food)
    {
        var validationResult = await _validator.ValidateAsync(food);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

        var saved = await _repository.GetFood(food.Id);
        var updatedSaved = CreateUpdateOrDeleteFoodAsync(saved, food);

        return updatedSaved != null ? await _repository.SaveFood(updatedSaved) : await _repository.DeleteFood(saved);
    }

    private static Food CreateUpdateOrDeleteFoodAsync(Food saved, FoodDto updated)
    {
        Food CreateFood(FoodDto updated)
        {
            var @new = new Food();
            return UpdateFood(@new, updated);
        }

        Food UpdateFood(Food saved, FoodDto updated)
        {
            saved.Name = updated.Name;
            saved.Measurement = updated.Measurement;
            saved.MeasurementTypeId = (int?)updated.MeasurementTypeId;
            saved.DepartmentId = (int?)updated.DepartmentId;
            saved.PreferredBrandId = updated.PreferredBrandId;
            saved.PreferredStoreId = updated.PreferredStoreId;
            return saved;
        }

        Food DeleteFood(Food saved)
        {
            return null;
        }

        if (updated.Delete) return DeleteFood(saved);
        else if (saved == null && updated != null) return CreateFood(updated);
        else if (saved != null && updated != null) return UpdateFood(saved, updated);
        else throw new SystemException("Unexpected values found!");
    }
}

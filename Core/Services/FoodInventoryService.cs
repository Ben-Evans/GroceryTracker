namespace Core.Services;

public interface IFoodInventoryService
{
    Task<IList<Food>> GetFoodInventory(InventoryQuery query);
    Task<Food> GetFood(int id);
    Task<bool> UpdateFood();//FoodDto food);
}

public class FoodInventoryService // : IFoodInventoryService
{
}

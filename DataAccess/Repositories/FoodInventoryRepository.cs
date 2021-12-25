namespace DataAccess.Repositories;

public interface IFoodInventoryRepository
{
    Task<IQueryable<Food>> GetFoodInventory();
    Task<Food> GetFood(int id);
    Task<bool> SaveFood(params Food[] foods);
    Task<bool> DeleteFood(params Food[] foods);
}

public class FoodInventoryRepository : IFoodInventoryRepository
{
    private IDbAccess _dbAccess;

    public FoodInventoryRepository(IDbAccess dbAccess)
    {
        _dbAccess = dbAccess;
    }

    public Task<Food> GetFood(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<Food>> GetFoodInventory()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveFood(params Food[] foods)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteFood(params Food[] foods)
    {
        throw new NotImplementedException();
    }
}

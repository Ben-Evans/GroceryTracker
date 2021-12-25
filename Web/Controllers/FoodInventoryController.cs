namespace Web.Controllers;

public interface IFoodInventoryController
{
}

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FoodInventoryController : ControllerBase, IFoodInventoryController
{
    private readonly ILogger<FoodInventoryController> _logger;
    private readonly IFoodInventoryService _service;
    private readonly IFoodInventoryValidator _validator;

    public FoodInventoryController(
        ILogger<FoodInventoryController> logger,
        IFoodInventoryService service,
        IFoodInventoryValidator validator)
    {
        _logger = logger;
        _service = service;
        _validator = validator;
    }

    [HttpGet]
    public async Task<IActionResult> GetInventory([FromBody] InventoryQuery query)
    {
        var inventoryList = await _service.GetFoodInventory(query);
        return Ok(inventoryList);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFood([FromQuery] int id)
    {
        var item = await _service.GetFood(id);
        return Ok(item);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFood()//[FromQuery] FoodDto food)
    {
        var item = await _service.UpdateFood();
        return Ok(item);
    }
}

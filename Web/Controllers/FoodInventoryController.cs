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
        try
        {
            var inventoryList = await _service.GetFoodInventory(query);
            return Ok(inventoryList);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFood([FromQuery] int id)
    {
        try
        {
            var item = await _service.GetFood(id);
            return Ok(item);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public async Task<IActionResult> UpdateFood([FromQuery] FoodDto food)
    {
        try
        {
            var item = await _service.UpdateFood(food);
            return Ok(item);
        }
        catch (ValidationException ex)
        {
            // TODO: Test this!
            return ValidationProblem(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}

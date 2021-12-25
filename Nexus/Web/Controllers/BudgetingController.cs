namespace Web.Controllers;

public interface IBudgetingController
{
}

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BudgetingController : ControllerBase, IBudgetingController
{
}

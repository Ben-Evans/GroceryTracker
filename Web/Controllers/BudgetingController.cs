namespace Web.Controllers;

public interface IBudgetingController
{
}

public class BudgetingController : BaseApiController<IBudgetingController>, IBudgetingController
{
    public BudgetingController(ILogger<IBudgetingController> logger)
        : base(logger)
    {
    }
}

using Microsoft.AspNetCore.Mvc;

public class CalculatorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

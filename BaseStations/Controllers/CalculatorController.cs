using Microsoft.AspNetCore.Mvc;

public class CalculatorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Calculate(double operand1, double operand2, string operation)
    {
        double result = 0;
        switch (operation)
        {
            case "add":
                result = operand1 + operand2;
                break;
            case "subtract":
                result = operand1 - operand2;
                break;
            case "multiply":
                result = operand1 * operand2;
                break;
            case "divide":
                if (operand2 != 0)
                {
                    result = operand1 / operand2;
                }
                else
                {
                    ViewBag.ErrorMessage = "Деление на ноль невозможно.";
                    return View("Index");
                }
                break;
        }
        ViewBag.Result = result;
        return View("Index");
    }

    public IActionResult BackToPrevious()
    {        
        return Redirect(Request.Headers["Referer"].ToString());
    }
}

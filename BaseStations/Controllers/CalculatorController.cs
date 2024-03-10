using Microsoft.AspNetCore.Mvc;

public class CalculatorController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    /*public IActionResult Index(double lonDegrees1, double lonMinutes1, double lonSeconds1)
    {
        double resultX = lonDegrees1 + (lonMinutes1 / 60) + (lonSeconds1 / 3600);

        // Здесь можно выполнить другие расчеты, если необходимо

        ViewData["calculationResultX"] = resultX;

        return View();
    }*/

    /*public IActionResult BackToPrevious()
    {        
        return Redirect(Request.Headers["Referer"].ToString());
    }*/
}

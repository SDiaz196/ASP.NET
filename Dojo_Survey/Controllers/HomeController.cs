using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("/results")]
    public IActionResult Result()
    {
        return View("Result");
    }

    [HttpPost("newStudent")]
    public IActionResult NewStudent(string Name, string Location, string Language, string Comment)
    {
        TempData["Name"] = Name;
        TempData["Location"] = Location;
        TempData["Language"] = Language;
        TempData["Comment"] = Comment;
        Console.WriteLine($"{Name} is attending the {Location} Dojo and their favorite language is {Language}!{Comment} ");
        return Redirect("/results");
    }
}
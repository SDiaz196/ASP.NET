using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey_Validations.Models;

namespace DojoSurvey_Validations.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }



    [HttpPost("/newStudent")]
    public IActionResult Create(Survey newSurvey)
    {

        if(!ModelState.IsValid) 
        {
            return View("Index");
        }

        Console.WriteLine("Name:" + newSurvey.Name);
        Console.WriteLine("Location:" + newSurvey.Location);
        Console.WriteLine("Language:" + newSurvey.Language);
        Console.WriteLine("Comment:" + newSurvey.Comment);
        return View("Result", newSurvey);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

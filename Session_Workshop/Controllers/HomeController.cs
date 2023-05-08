using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session_Workshop.Models;

namespace Session_Workshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }

    [HttpGet("/dashboard")]
    public IActionResult Dashboard()
    {
        int CurrentNum = HttpContext.Session.GetInt32("Num") ?? 22;
        HttpContext.Session.SetInt32("Num", (int)CurrentNum);
        return View("Dashboard");
    }

    [HttpPost("/session")]
    public IActionResult Create(User newUser)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        HttpContext.Session.SetString("UserName", newUser.Name);
        string? SessionName = HttpContext.Session.GetString("UserName");

        Console.WriteLine(newUser.Name);
        Console.WriteLine(SessionName);
        return Redirect("Dashboard");
    }

    [HttpPost("/dashboard")]
    public IActionResult Num(string action)
    {
        int CurrentNum = HttpContext.Session.GetInt32("Num") ?? 22;
        switch (action)
        {
            case "add":
                CurrentNum += 1;
                break;
            case "subtract":
                CurrentNum -= 1;
                break;
            case "multiply":
                CurrentNum *= 2;
                break;
            case "random":
                Random rand = new Random();
                int randomNum = rand.Next(1, 11);
                CurrentNum += randomNum;
                break;
            default:
                break;
        }

        HttpContext.Session.SetInt32("Num", CurrentNum);
        return Redirect("Dashboard");
    }

    [HttpPost("/clear")]
    public IActionResult Clear()
    {
        HttpContext.Session.Clear();
        return Redirect("/");
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

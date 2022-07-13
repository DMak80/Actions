using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Homework7.Models;

namespace Homework7.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [ExcludeFromCodeCoverage]
    public IActionResult Index()
    {
        return View();
    }

    [ExcludeFromCodeCoverage]
    public IActionResult Privacy()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult UserProfile()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UserProfile(UserProfile profile)
    {
        return View(profile);
    }
    
    [ExcludeFromCodeCoverage]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
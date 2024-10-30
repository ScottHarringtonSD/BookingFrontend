using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingFrontEnd.Models;

namespace BookingFrontEnd.Controllers;

public class LoginController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly ILoginClient _loginClient;


    public LoginController(ILoginClient loginClient, ILogger<HomeController> logger)
    {
        _loginClient = loginClient;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetCredentials(Credentials credentials){
        var token = _loginClient.Login(credentials);
        SetCookie("token", token);
        return RedirectToAction("Index", "Home");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }


    private void SetCookie(string key, string value)
    {
        HttpContext.Response.Cookies.Append(key, value, new CookieOptions
        {
            Expires = DateTimeOffset.UtcNow.AddMinutes(300),
            HttpOnly = true, // Accessible only by the server
            IsEssential = true // Required for GDPR compliance
        });
    }
}

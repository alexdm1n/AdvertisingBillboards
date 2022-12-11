using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboards.Controllers;

// Temporary stub to check project startup
// Main logic be implemented later

public class HomeController : Controller
{
    private readonly IUserService _userService;

    public HomeController(IUserService userService)
    {
        _userService = userService;
    }

    public IActionResult Index()
    {
        var users = _userService.GetAll();
        return View(users);
    }
}
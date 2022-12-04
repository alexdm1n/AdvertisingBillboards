using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboards.Controllers;

public class UserController : Controller
{
    public IActionResult Devices()
    {
        return View();
    }

    public IActionResult DeviceGroups()
    {
        return View();
    }

    public IActionResult Advertisement()
    {
        return View();
    }

    public IActionResult DevicesInGroup()
    {
        return View();
    }
}
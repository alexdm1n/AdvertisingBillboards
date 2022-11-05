using Microsoft.AspNetCore.Mvc;

namespace AdvertisingBillboards.Controllers;

public class UserController : Controller
{
    public IActionResult Devices()
    {
        return View();
    }
}
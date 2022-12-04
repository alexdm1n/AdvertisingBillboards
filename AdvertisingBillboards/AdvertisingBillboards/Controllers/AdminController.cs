using AdvertisingBillboards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvertisingBillboards.Controllers;

public class AdminController : Controller
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
        var viewBag = _adminService.GetModelsCount();
        ViewBag.DeviceAmount = viewBag.DevicesAmount;
        ViewBag.UserAmount = viewBag.UsersAmount;
        ViewBag.FileAmount = viewBag.AdvertisementsAmount;
    }

    public IActionResult Devices()
    {
        return View();
    }

    public IActionResult DeviceGroups()
    {
        return View();
    }

    public IActionResult Advertisement(long deviceId)
    {
        var advertisement = _adminService.Advertisement(deviceId);
        return View(advertisement);
    }

    public IActionResult UsersList()
    {
        return View();
    }
}
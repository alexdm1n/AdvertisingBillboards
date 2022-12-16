using AdvertisingBillboards.Models.Models;
using AdvertisingBillboards.Services;
using AdvertisingBillboards.Src.AdvertisingBillboards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdvertisingBillboards.Controllers;

public class UserController : Controller
{
    private readonly IUserControllerService _userService;

    public UserController(IUserControllerService userService)
    {
        _userService = userService;
    }

    public IActionResult Devices(long? userId = null)
    {
        var devicesViewModel = _userService.Devices(userId);
        return View(devicesViewModel);
    }

    public IActionResult DeviceGroups()
    {
        var deviceGroupsViewModel = _userService.DeviceGroups();
        return View(deviceGroupsViewModel);
    }

    public IActionResult Advertisement(long deviceId)
    {
        var advertisement = _userService.Advertisement(deviceId);
        return View(advertisement);
    }
    public IActionResult SubmitFrequencyForDevice(long deviceId, int frequency)
    {
        _userService.SubmitFrequencyForDevice(deviceId, frequency);
        return RedirectToAction("Devices", "User");
    }
}
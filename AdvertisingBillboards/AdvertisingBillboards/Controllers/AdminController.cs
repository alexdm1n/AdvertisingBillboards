using AdvertisingBillboards.Models.Models;
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

    public IActionResult Devices()
    {
        var devicesViewModel = _adminService.Devices();
        return View(devicesViewModel);
    }

    public IActionResult DeviceGroups()
    {
        var deviceGroupsViewModel = _adminService.DeviceGroups();
        return View(deviceGroupsViewModel);
    }

    public IActionResult Advertisement(long deviceId)
    {
        var advertisement = _adminService.Advertisement(deviceId);
        return View(advertisement);
    }

    public IActionResult UsersList()
    {
        var users = _adminService.UsersList();
        return View(users);
    }
    
    public IActionResult AdvertisementStatistics(long advertisementId)
    {
        var statistics = _adminService.AdvertisementStatistics(advertisementId);
        return View(statistics);
    }

    [HttpPost]
    public IActionResult AddUser(string name)
    {
        _adminService.AddUser(name);
        return RedirectToAction("UsersList", "Admin");
    }

    [HttpPost]
    public IActionResult DeleteUser(long userId)
    {
        _adminService.DeleteUser(userId);
        return RedirectToAction("UsersList", "Admin");
    }

    [HttpPost]
    public IActionResult AddDevice(long userId)
    {
        _adminService.AddDevice(userId);
        return RedirectToAction("Devices", "Admin");
    }

    [HttpPost]
    public IActionResult DeleteDevice(long id)
    {
        _adminService.DeleteDevice(id);
        return RedirectToAction("Devices", "Admin");
    }

    public IActionResult AddDeviceGroup(long userId)
    {
        _adminService.AddDeviceGroup(userId);
        return RedirectToAction("DeviceGroups", "Admin");
    }

    public IActionResult DeleteDeviceGroup(long deviceGroupId)
    {
        _adminService.DeleteDeviceGroup(deviceGroupId);
        return RedirectToAction("DeviceGroups", "Admin");
    }
    
    public IActionResult DeleteAdvertising(long advId)
    {
        _adminService.DeleteAdvertisement(advId);
        return RedirectToAction("Devices", "Admin");
    }

    [HttpPost]
    public IActionResult UploadVideo(IFormFile uploadedVideo, long deviceId)
    {
        if (uploadedVideo?.ContentType != "video/mp4")
        {
            return RedirectToAction("Advertisement", new { deviceId });
        }

        _adminService.UploadVideo(uploadedVideo, deviceId);
        return RedirectToAction("Advertisement", new { deviceId });
    }

    public IActionResult SubmitFrequencyForDevice(long deviceId, int frequency)
    {
        _adminService.SubmitFrequencyForDevice(deviceId, frequency);
        return RedirectToAction("Devices", "Admin");
    }

    public IActionResult SubmitFrequencyForDeviceGroup(long deviceGroupId, int frequency)
    {
        _adminService.SubmitFrequencyForDeviceGroup(deviceGroupId, frequency);
        return RedirectToAction("DeviceGroups", "Admin");
    }
}
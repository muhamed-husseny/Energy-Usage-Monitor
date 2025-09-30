namespace Energy_Usage_Monitor.PL.Controllers
{
    public class DeviceController : Controller
    {
        #region Services
        public readonly IElectricalDeviceService _deviceServices;

        public DeviceController(IElectricalDeviceService deviceService)
        {
            _deviceServices = deviceService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var devices = await _deviceServices.GetAllDevicesAsync();
            return View(devices);
        } 
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceForCreationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _deviceServices.CreateDeviceAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var device = await _deviceServices.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound();

            var dto = new DeviceForUpdateDto
            {
                Name = device.Name,
                Type = device.Type,
                PowerRatingWatts = device.PowerRatingWatts,
                IsOn = device.IsOn,
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeviceForUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var updated = await _deviceServices.UpdateDevice(id, dto);
            if (!updated)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var device = await _deviceServices.GetDeviceByIdAsync(id);
            if (device == null)
                return NotFound();

            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await _deviceServices.DeleteDevice(id);
            if (!deleted)
            {
                return NotFound();
            }              
            return RedirectToAction(nameof(Index));
        }

        #endregion


    }
}

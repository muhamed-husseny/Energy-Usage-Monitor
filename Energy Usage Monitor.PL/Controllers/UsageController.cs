namespace Energy_Usage_Monitor.PL.Controllers
{
    public class UsageController : Controller
    {
        #region Services
        private readonly IDeviceUsageService _usageService;

        public UsageController(IDeviceUsageService usageService)
        {
            _usageService = usageService;
        }
        [HttpGet]
        public async Task<IActionResult> Index(int deviceId)
        {
            var usages = await _usageService.GetAllUsagesByDeviceIdAsync(deviceId);
            ViewBag.DeviceId = deviceId;

            return View(usages);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create(int deviceId)
        {
            var dto = new DeviceUsageForCreationDto
            {
                ElectricalDeviceId = deviceId
            };
            return View(dto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeviceUsageForCreationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var createdUsage = await _usageService.CreateUsageAsync(dto);

            return RedirectToAction(nameof(Index), new { deviceId = dto.ElectricalDeviceId });

        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int usageId)
        {
            var usage = await _usageService.GetUsageByIdAsync(usageId);
            if (usage == null)
                return NotFound();

            return View(usage);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int usageId) 
        {
            var deleted = await _usageService.DeleteUsageAsync(usageId);
            if (!deleted) return NotFound();

            var usage = await _usageService.GetUsageByIdAsync(usageId);
            var deviceId = usage?.ElectricalDeviceId;

            return RedirectToAction(nameof(Index), new { deviceId });
        }

        #endregion
    }
}

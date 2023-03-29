using Microsoft.AspNetCore.Mvc;
using SearchAPI.Models;
using SearchAPI.Services;

namespace SearchAPI.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService ?? throw new ArgumentNullException(nameof(dashboardService));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> GetDashboardDetails([FromBody] DashboardFilters request) =>
            Ok(await _dashboardService.GetDashboardDetails(request));

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get([FromBody] DashboardFilters request) =>
            Ok(await _dashboardService.GetDashboardDetails(request));
    }
}

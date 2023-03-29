using SearchAPI.Models;

namespace SearchAPI.Services
{
    public interface IDashboardService
    {
        Task<DashboardSummaryResult> GetDashboardDetails(DashboardFilters filters);
    }
}

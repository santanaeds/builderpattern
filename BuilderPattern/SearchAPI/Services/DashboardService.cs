using SearchAPI.Builders;
using SearchAPI.Models;
using SearchAPI.Providers;

namespace SearchAPI.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ISearchApiServiceProvider _searchServiceProvider;

        public DashboardService(ISearchApiServiceProvider searchServiceProvider)
        {
            _searchServiceProvider = searchServiceProvider ?? throw new ArgumentNullException(nameof(ISearchApiServiceProvider));
        }

        public async Task<DashboardSummaryResult> GetDashboardDetails(DashboardFilters filters)
        {
            _ = filters ?? throw new ArgumentNullException(nameof(filters));

            if (string.IsNullOrWhiteSpace(filters.ProgramInstanceValue)) filters.ProgramInstanceValue = "2022/23";

            Task<IEnumerable<SchoolIndexModel>> task1 = SearchSchools(filters);
            Task<IEnumerable<VolunteerIndexModel>> task2 = SearchVolunteers(filters);

            var responseBuilder = new DashboardResponseBuilder();
            await Task.WhenAll(task1, task2);

            responseBuilder.WithSchools(task1.Result);
            responseBuilder.WithClasses(task1.Result.SelectMany(s => s.Classes));
            responseBuilder.WithVolunteers(task2.Result);

            return responseBuilder.SetActionsToTake()
                .SetVolunteerSummaries()
                .SetSchoolSummaries()
                .BuildResponse();
        }

        private async Task<IEnumerable<SchoolIndexModel>> SearchSchools(DashboardFilters filters)
        {
            return await _searchServiceProvider.SearchSchools(new SearchApiFilters()
            {
                ProgramInstanceValue = filters.ProgramInstanceValue,
                RegionalManagerIds = filters.RegionalManagers,
                States = filters.States
            });
        }

        private async Task<IEnumerable<VolunteerIndexModel>> SearchVolunteers(DashboardFilters filters)
        {
            return await _searchServiceProvider.SearchVolunteers(new SearchApiFilters()
            {
                ProgramInstanceValue = filters.ProgramInstanceValue,
                RegionalManagerIds = filters.RegionalManagers,
                States = filters.States
            });
        }
    }
}

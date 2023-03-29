using SearchAPI.Models;

namespace SearchAPI.Providers
{
    public interface ISearchApiServiceProvider
    {
        Task<IEnumerable<SchoolIndexModel>> SearchSchools(SearchApiFilters request);
        Task<IEnumerable<VolunteerIndexModel>> SearchVolunteers(SearchApiFilters request);
    }
}

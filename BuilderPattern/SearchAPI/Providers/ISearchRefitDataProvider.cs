using Refit;
using SearchAPI.Models;

namespace SearchAPI.Providers
{
    public interface ISearchRefitDataProvider
    {
        [Post("/indexes/schools/docs/search?api-version=2021-04-30-Preview")]
        Task<SearchApiResponse<SchoolIndexModel>> SearchSchools(SearchApiRequest request);

        [Post("/indexes/volunteers/docs/search?api-version=2021-04-30-Preview")]
        Task<SearchApiResponse<VolunteerIndexModel>> SearchVolunteers(SearchApiRequest request);
    }
}

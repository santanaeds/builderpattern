using Refit;
using SearchAPI.Models;
using static SearchAPI.Models.Constants;

namespace SearchAPI.Providers
{
    public class SearchApiServiceProvider : ISearchApiServiceProvider
    {
        private readonly ISearchRefitDataProvider _dataProvider;
        private readonly ILogger<SearchApiServiceProvider> _logger;

        public SearchApiServiceProvider(ISearchRefitDataProvider dataProvider, ILogger<SearchApiServiceProvider> logger)
        {
            _dataProvider = dataProvider ?? throw new ArgumentNullException(nameof(ISearchRefitDataProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<SchoolIndexModel>> SearchSchools(SearchApiFilters request)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                if (string.IsNullOrWhiteSpace(request.SearchText)) request.SearchText = "*";

                var items = new List<SchoolIndexModel>();
                var nextParams = new SearchApiRequest()
                {
                    search = request.SearchText,
                    count = true,
                    filter = ConstructSchoolFilters(request, SearchIndexNames.Schools),
                    top = 5000,
                    skip = 0
                };

                do
                {
                    var response = await _dataProvider.SearchSchools(nextParams);
                    if (response.Items.Any()) items.AddRange(response.Items);
                    nextParams = response.NextParameters;
                } while (nextParams != null);

                return items;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, $"Error while fetching data from index API {SearchIndexNames.Schools}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching data from index API {SearchIndexNames.Schools}");
                throw;
            }
        }

        public async Task<IEnumerable<VolunteerIndexModel>> SearchVolunteers(SearchApiFilters request)
        {
            try
            {
                if (request == null) throw new ArgumentNullException(nameof(request));
                if (string.IsNullOrWhiteSpace(request.SearchText)) request.SearchText = "*";

                var items = new List<VolunteerIndexModel>();
                var nextParams = new SearchApiRequest()
                {
                    search = request.SearchText,
                    count = true,
                    filter = ConstructSchoolFilters(request, SearchIndexNames.Volunteer),
                    top = 5000,
                    skip = 0
                };

                do
                {
                    var response = await _dataProvider.SearchVolunteers(nextParams);
                    if (response.Items.Any()) items.AddRange(response.Items);
                    nextParams = response.NextParameters;
                } while (nextParams != null);

                return items;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, $"Error while fetching data from index API {SearchIndexNames.Volunteer}");
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error while fetching data from index API {SearchIndexNames.Volunteer}");
                throw;
            }
        }

        private static string ConstructSchoolFilters(SearchApiFilters filters, string indexName)
        {
            if (string.IsNullOrWhiteSpace(indexName)) throw new ArgumentNullException(indexName);

            List<string> list = new();
            if (!string.IsNullOrWhiteSpace(filters.ProgramInstanceId))
                list.Add($"ProgramInstanceId eq '{filters.ProgramInstanceId}'");
            if (!string.IsNullOrWhiteSpace(filters.ProgramInstanceValue))
                list.Add($"ProgramInstanceValue eq '{filters.ProgramInstanceValue}'");

            if (string.Equals(indexName, SearchIndexNames.Volunteer, StringComparison.OrdinalIgnoreCase))
            {
                if (filters.RegionalManagerIds != null && filters.RegionalManagerIds.Any())
                    list.Add($"search.in(RegionalManagerId,'{string.Join(",", filters.RegionalManagerIds)}', ',')");
                if (filters.RegionalManagerNames != null && filters.RegionalManagerNames.Any())
                    list.Add($"search.in(RegionalManagerName,'{string.Join(",", filters.RegionalManagerNames)}', ',')");
                if (filters.States != null && filters.States.Any())
                    list.Add($"search.in(HomeState, '{string.Join(",", filters.States)}', ',')");
                if (!string.IsNullOrWhiteSpace(filters.SingleStatus))
                    list.Add($"VolunteerStatus eq '{filters.SingleStatus}'");
                if (filters.Status != null && filters.Status.Any())
                    list.Add($"search.in(VolunteerStatus, '{string.Join(",", filters.Status)}', ',')");
            }

            if (string.Equals(indexName, SearchIndexNames.Schools, StringComparison.OrdinalIgnoreCase))
            {
                if (filters.RegionalManagerIds != null && filters.RegionalManagerIds.Any())
                    list.Add($"search.in(RegionalManagerId,'{string.Join(",", filters.RegionalManagerIds)}', ',')");
                if (filters.RegionalManagerNames != null && filters.RegionalManagerNames.Any())
                    list.Add($"search.in(RegionalManagerName,'{string.Join(",", filters.RegionalManagerNames)}', ',')");
                if (filters.States != null && filters.States.Any())
                    list.Add($"search.in(State,'{string.Join(",", filters.States)}', ',')");
                if (!string.IsNullOrWhiteSpace(filters.SingleStatus))
                    list.Add($"Status eq '{filters.SingleStatus}'");
                if (filters.Status != null && filters.Status.Any())
                    list.Add($"search.in(Status,'{string.Join(",", filters.Status)}', ',')");
            }

            return list.Any() ? string.Join(" and ", list) : string.Empty;
        }
    }
}

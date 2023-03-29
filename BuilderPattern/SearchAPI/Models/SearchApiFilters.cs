namespace SearchAPI.Models
{
    public class SearchApiFilters
    {
        public string SearchText { get; set; }
        public string ProgramInstanceId { get; set; }
        public string ProgramInstanceValue { get; set; }
        public string SingleStatus { get; set; }
        public IEnumerable<string> Status { get; set; }
        public IEnumerable<string> RegionalManagerIds { get; set; }
        public IEnumerable<string> RegionalManagerNames { get; set; }
        public IEnumerable<string> States { get; set; }
    }
}

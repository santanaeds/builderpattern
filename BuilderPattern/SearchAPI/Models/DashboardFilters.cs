namespace SearchAPI.Models
{
    public class DashboardFilters
    {
        public string ProgramInstanceValue { get; set; }
        public IEnumerable<string> RegionalManagers { get; set; }
        public IEnumerable<string> States { get; set; }
    }
}

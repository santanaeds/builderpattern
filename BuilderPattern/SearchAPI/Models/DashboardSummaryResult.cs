namespace SearchAPI.Models
{
    public class DashboardSummaryResult
    {
        public ActionsToTakeResult ActionsToTake { get; set; }
        public Dictionary<SummaryType, SummaryItemResult> Summaries { get; set; }
    }
}

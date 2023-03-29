namespace SearchAPI.Models
{
    public class SummaryItemResult
    {
        public int NeedAttentionCount { get; set; } = 0;
        public IEnumerable<OverviewItemResult> Overviews { get; set; } = new List<OverviewItemResult>();
    }
}

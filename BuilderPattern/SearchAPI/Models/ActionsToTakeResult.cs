namespace SearchAPI.Models
{
    public class ActionsToTakeResult
    {
        public IEnumerable<ActionsToTakeItem> Items { get; set; } = new List<ActionsToTakeItem>();
    }
}

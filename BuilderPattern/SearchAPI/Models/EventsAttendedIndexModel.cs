namespace SearchAPI.Models
{
    public class EventsAttendedIndexModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string RegionName { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}

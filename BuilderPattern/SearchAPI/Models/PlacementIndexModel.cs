namespace SearchAPI.Models
{
    public class PlacementIndexModel
    {
        public string Status { get; set; }
        public string Role { get; set; }
        public string PlacedBy { get; set; }
        public DateTimeOffset? PlacedDate { get; set; }
        public bool IsTechSpark { get; set; }
        public bool IsRemote { get; set; }
        public string ClassType { get; set; }
        public string ClassSubType { get; set; }
        public string CourseName { get; set; }
        public string CourseLength { get; set; }
        public string Model { get; set; }
        public string Section { get; set; }
        public string SchoolName { get; set; }
    }
}

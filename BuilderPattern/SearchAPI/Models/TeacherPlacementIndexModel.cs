namespace SearchAPI.Models
{
    public class TeacherPlacementIndexModel
    {
        public string TeacherId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PlacedBy { get; set; }
        public DateTimeOffset? PlacedDate { get; set; }
    }
}

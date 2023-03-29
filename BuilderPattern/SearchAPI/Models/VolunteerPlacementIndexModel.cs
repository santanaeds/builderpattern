namespace SearchAPI.Models
{
    public class VolunteerPlacementIndexModel
    {
        public string VolunteerId { get; set; }
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string PlacedBy { get; set; }
        public DateTimeOffset? PlacedDate { get; set; }
        public string RoleDescription { get; set; }
        public bool? IsReturning { get; set; }
    }
}

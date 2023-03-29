namespace SearchAPI.Models
{
    public class StaffIndexModel
    {
        public string RepresentativeId { get; set; }
        public string Title { get; set; }
        public bool? TShirtRequired { get; set; }
        public string TShirtPreferredFit { get; set; }
        public string TShirtSize { get; set; }
        public DateTimeOffset? TShirtShippedDate { get; set; }
        public DateTimeOffset? CertificateShippedDate { get; set; }
        public List<string> Roles { get; set; }
        public string WPUserId { get; set; }
        public string WPAppId { get; set; }
        public string PhotoUrl { get; set; }
        public string FullName { get; set; }
        public string PreferredEmail { get; set; }
        public string PreferredPhone { get; set; }
        public string SchoolYearWithTeals { get; set; }
        public int? TotalYearsInTeals { get; set; }
        public bool AppliedPreviously { get; set; }
        public bool IsReturning { get; set; }
        public List<EventsAttendedIndexModel> Events { get; set; } = new List<EventsAttendedIndexModel>();
    }
}

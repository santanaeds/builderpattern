using Newtonsoft.Json;

namespace SearchAPI.Models
{
    public class VolunteerIndexModel
    {
        [JsonProperty("id")]
        public string Id => $"{VolunteerId}_{ProgramInstanceId}";
        public string ProgramInstanceId { set; get; }
        public string ProgramInstanceValue { get; set; }
        public string VolunteerId { get; set; }
        public string WPUserId { get; set; }
        public string WPAppId { get; set; }
        public string PhotoUrl { get; set; }
        public string PreferredName { get; set; }
        public string FullName { get; set; }
        public string PreferredEmail { get; set; }
        public string PreferredPhone { get; set; }
        public string RegionalManagerId { get; set; }
        public string RegionalManagerName { get; set; }
        public string RegionalManagerEmail { get; set; }
        public string WithdrawReason { get; set; }
        public DateTimeOffset? WithdrawDate { get; set; }
        public DateTimeOffset? InvitedDate { get; set; }
        public DateTimeOffset? ReminderSentDate { get; set; }
        public DateTimeOffset? AppSubmissionDate { get; set; }
        public string InterviewStatus { get; set; }
        public DateTimeOffset? InterviewDate { get; set; }
        public string VolunteerStatus { get; set; }
        public bool AgreementSigned { get; set; }
        public DateTimeOffset? CreatedDate { get; set; }
        public string SubregionTag { get; set; }
        public string HomeAddress { get; set; }
        public string HomeCity { get; set; }
        public string HomeState { get; set; }
        public string HomeCountry { get; set; }
        public string HomeZipCode { get; set; }
        public float[] HomeCoordinates { get; set; }
        public string WorkAddress { get; set; }
        public string WorkCity { get; set; }
        public string WorkState { get; set; }
        public string WorkCountry { get; set; }
        public string WorkZipCode { get; set; }
        public string EarliestAvailability { get; set; }
        public string LatestAvailability { get; set; }
        public bool? ReturnSamePlacement { get; set; }
        public string RolePreferences { get; set; }
        public string CommutePreference { get; set; }
        public string RemotePreference { get; set; }
        public string PreferredClassTime { get; set; }
        public string FirstRemotePreferenceSchoolNames { get; set; }
        public string SecondRemotePreferenceSchoolNames { get; set; }
        public bool? ReadyForRemoteTeaching { get; set; }
        public string Employer { get; set; }
        public string CurrentEmploymentStatus { get; set; }
        public string EmployerIndustry { get; set; }
        public string EmployerOrganizationType { get; set; }
        public string EmploymentWorkType { get; set; }
        public string EmploymentTitle { get; set; }
        public string MSFTAlias { get; set; }
        public bool IsMSFTEmployee { get; set; }
        public string MSFTTeam { get; set; }
        public string SchoolYearWithTeals { get; set; }
        public int? TotalYearsInTeals { get; set; }
        public bool? AppliedPreviously { get; set; }
        public bool IsReturning { get; set; }
        public string Timezone { get; set; }
        public List<PlacementIndexModel> Placements { get; set; } = new List<PlacementIndexModel>();
    }
}

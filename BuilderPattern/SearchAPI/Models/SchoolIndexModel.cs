using Newtonsoft.Json;

namespace SearchAPI.Models
{
    public class SchoolIndexModel
    {
        [JsonProperty("id")]
        public string Id => $"{SchoolId}_{ProgramInstanceId}";
        public string ProgramInstanceId { set; get; }
        public string SchoolId { get; set; }
        public string WPCode { get; set; }
        public string WPAppId { get; set; }
        public string SchoolName { get; set; }
        public string ProgramInstanceValue { get; set; }
        public string RegionalManagerName { get; set; }
        public string RegionalManagerId { get; set; }
        public string RegionalManagerEmail { get; set; }
        public string NCESSchoolId { get; set; }
        public string SchoolType { get; set; }
        public string Status { get; set; }
        public bool IsRemote { get; set; }
        public bool MOUEnabled { get; set; }
        public bool MOUCompleted { get; set; }
        public bool PaperSignedMou { get; set; }
        public string EthicsPolicy { get; set; }
        public string MOUSignatures { get; set; }
        public string ApAuth { get; set; }
        public string District { get; set; }
        public string InterviewStatus { get; set; }
        public DateTimeOffset? InvitedDate { get; set; }
        public DateTimeOffset? InterviewDate { get; set; }
        public string InterviewTime { get; set; }
        public string InterviewTimeZone { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public float[] Coordinates { get; set; }
        public DateTimeOffset? SubmissionDate { get; set; }
        public int TotalYearsInTeals { get; set; }
        public bool IsReturning { get; set; }
        public string SchoolYearWithTeals { get; set; }
        public string SubregionTag { get; set; }
        public List<StaffIndexModel> Staff { get; set; } = new List<StaffIndexModel>();
        public List<ClassItemIndexModel> Classes { get; set; } = new List<ClassItemIndexModel>();
        public string IsTechSpark { get; set; }
    }
}

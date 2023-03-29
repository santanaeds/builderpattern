namespace SearchAPI.Models
{
    public class ClassItemIndexModel
    {
        public string Id { get; set; }
        public string TypeDescription { get; set; }
        public string SubTypeDescription { get; set; }
        public string Model { get; set; }
        public string ClassName { get; set; }
        public string Section { get; set; }
        public string CourseLength { get; set; }
        public string ClassroomPlanLink { get; set; }
        public bool IsRemote { get; set; }
        public string IsTechSpark { get; set; }
        public int RequiredTA { get; set; }
        public int RequiredCT { get; set; }
        public int RequiredObservations { get; set; }
        public string CourseOutcomeStatus { get; set; }
        public string CourseOutcomeComments { get; set; }
        public string TotalDemographics { get; set; }
        public double? Average { get; set; }
        public int? One { get; set; }
        public int? Two { get; set; }
        public int? Three { get; set; }
        public int? Four { get; set; }
        public int? Five { get; set; }
        public int? Male { get; set; }
        public int? Female { get; set; }
        public decimal? Total { get; set; }
        public string APScoresSource { get; set; }
        public bool NoApExams { get; set; }
        public int TotalObservations { get; set; }
        public string ObservationsStatus { get; set; }
        public List<TeacherPlacementIndexModel> TeacherPlacements { get; set; } = new List<TeacherPlacementIndexModel>();
        public List<VolunteerPlacementIndexModel> VolunteerPlacements { get; set; } = new List<VolunteerPlacementIndexModel>();
        public List<string> Schedules { get; set; } = new List<string>();
    }
}

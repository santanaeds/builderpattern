using System.ComponentModel;

namespace SearchAPI.Models
{
    public enum SummaryType
    {
        SchoolApplications,
        SchoolInterviews,
        VolunteerApplications,
        VolunteerInterviews
    }

    public enum ActionsToTake
    {
        [Description("Classes with unassigned teachers")]
        ClassesWithNoTeachers,
        [Description("RM Observations")]
        RMObservations,
        [Description("Incomplete Student Enrollment")]
        IncompleteStudentEnrollment,
        [Description("Signed Ethics Policy")]
        SignedEthicsPolicy,
        [Description("Signed AP Auth")]
        SignedAPAuth,
        [Description("AP Scores")]
        APScores,
        [Description("Signed MOUs")]
        SignedMOUs,
        [Description("Signed Volunteers")]
        SignedVolunteers
    }

    public enum CourseTypeName
    {
        [Description("AP")]
        AP,
        [Description("Post AP")]
        PostAP,
        [Description("AP CSP")]
        APCSP,
        [Description("Cybersecurity")]
        Cybersecurity,
        [Description("Data Science/AI/ML")]
        DataScienceAIML,
        [Description("Intro to CS")]
        IntroToCS
    }

    public enum SchoolStatus
    {
        [Description("Undecided")]
        Undecided,
        [Description("Accept")]
        Accept,
        [Description("Evaluation In Progress")]
        EvaluationInProgress,
        [Description("WaitList")]
        WaitList,
        [Description("Withdraw")]
        Withdraw,
        [Description("Reject")]
        Reject,
        [Description("Move to Alumni")]
        MoveToAlumni,
        [Description("Draft")]
        Draft
    }

    public enum SchoolInterviewStatus
    {
        [Description("Completed")]
        Completed,
        [Description("Not needed")]
        NotNeeded,
        [Description("Required")]
        Required,
        [Description("Scheduling in progress")]
        SchedulingInProgress,
        [Description("Scheduled")]
        Scheduled,
        [Description("TBD")]
        TBD,
        [Description("Upcoming")]
        Upcoming,
        [Description("Not required")]
        NotRequired
    }

    public enum VolunteerStatus
    {
        [Description("Draft")]
        Draft,
        [Description("Accept")]
        Accept,
        [Description("Undecided")]
        Undecided,
        [Description("Evaluation in progress")]
        EvaluationInProgress,
        [Description("Waitlist")]
        Waitlist,
        [Description("Withdraw")]
        Withdraw,
        [Description("Reject")]
        Reject,
        [Description("Move to alumni")]
        MoveToAlumni
    }

    public enum VolunteerInterviewStatus
    {
        [Description("TBD")]
        TBD,
        [Description("Required")]
        Required,
        [Description("Upcoming")]
        Upcoming,
        [Description("Scheduling in progress")]
        SchedulingInProgress,
        [Description("Scheduled")]
        Scheduled,
        [Description("Completed")]
        Completed,
        [Description("Not needed")]
        NotNeeded
    }

    public enum VolunteerPlacementStatus
    {
        [Description("Placed")]
        Placed,
        [Description("Published")]
        Published
    }
}

using SearchAPI.Models;

namespace SearchAPI.Builders
{
    public interface IDashboardResponseBuilder
    {
        IDashboardResponseBuilder WithSchools(IEnumerable<SchoolIndexModel> schools);
        IDashboardResponseBuilder WithClasses(IEnumerable<ClassItemIndexModel> classDetails);
        IDashboardResponseBuilder WithVolunteers(IEnumerable<VolunteerIndexModel> volunteers);
        IDashboardResponseBuilder SetActionsToTake();
        IDashboardResponseBuilder SetSchoolSummaries();
        IDashboardResponseBuilder SetVolunteerSummaries();
        DashboardSummaryResult BuildResponse();
    }
}

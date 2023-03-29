using SearchAPI.Extensions;
using SearchAPI.Models;

namespace SearchAPI.Builders
{
    public class DashboardResponseBuilder : IDashboardResponseBuilder
    {
        private IEnumerable<SchoolIndexModel> _schools;
        private IEnumerable<VolunteerIndexModel> _volunteers;
        private IEnumerable<ClassItemIndexModel> _classes;
        private ActionsToTakeResult _actionsToTake;
        public Dictionary<SummaryType, SummaryItemResult> _summaries = new Dictionary<SummaryType, SummaryItemResult>();

        public DashboardSummaryResult BuildResponse()
        {
            return new DashboardSummaryResult()
            {
                ActionsToTake = _actionsToTake,
                Summaries = _summaries
            };
        }

        public IDashboardResponseBuilder SetActionsToTake()
        {
            var apClasses = _classes.Where(x => x.TypeDescription == CourseTypeName.AP.Description());
            var totalClasses = _classes.Count();
            var acceptedSchools = _schools.Where(x => string.Equals(x.Status, SchoolStatus.Accept.Description(), StringComparison.OrdinalIgnoreCase));
            var placedVolunteers = _volunteers.Where(x => x.Placements.Any(s => s.Status == VolunteerPlacementStatus.Published.Description()));

            _actionsToTake = new ActionsToTakeResult()
            {
                Items = new List<ActionsToTakeItem>()
                {
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.ClassesWithNoTeachers,
                        Total = totalClasses,
                        MetCriteria = _classes.Count(x => x.TeacherPlacements == null || !x.TeacherPlacements.Any())
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.RMObservations,
                        Total = _classes.Sum(x => x.RequiredObservations),
                        MetCriteria = _classes.Count(x => string.Equals(x.ObservationsStatus, "Completed", StringComparison.OrdinalIgnoreCase))
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.IncompleteStudentEnrollment,
                        Total = totalClasses,
                        MetCriteria = _classes.Count(x => !string.IsNullOrWhiteSpace(x.TotalDemographics) && Convert.ToInt32(x.TotalDemographics) == 0)
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.APScores,
                        Total = apClasses.Count(),
                        MetCriteria = apClasses.Count(x => x.NoApExams || x.Average != null)
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.SignedEthicsPolicy,
                        Total = acceptedSchools.Count(),
                        MetCriteria = acceptedSchools.Count(x => string.Equals(x.EthicsPolicy, "Authorized - Yes", StringComparison.OrdinalIgnoreCase))
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.SignedAPAuth,
                        Total = acceptedSchools.Count(x => x.Classes.Any(s => s.TypeDescription == CourseTypeName.AP.Description())),
                        MetCriteria = acceptedSchools.Count(x => string.Equals(x.ApAuth, "Yes", StringComparison.OrdinalIgnoreCase))
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.SignedMOUs,
                        Total = acceptedSchools.Count(),
                        MetCriteria = acceptedSchools.Count(x => x.MOUCompleted)
                    },
                    new ActionsToTakeItem()
                    {
                        Action = ActionsToTake.SignedVolunteers,
                        Total = placedVolunteers.Count(),
                        MetCriteria = placedVolunteers.Count(x => x.AgreementSigned)
                    }
                }
            };
            return this;
        }

        public IDashboardResponseBuilder SetSchoolSummaries()
        {
            _summaries.Add(SummaryType.SchoolApplications, new SummaryItemResult()
            {
                NeedAttentionCount = 0,
                Overviews = new List<OverviewItemResult>()
                    {
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.Undecided.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.Undecided.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.Accept.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.Accept.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.EvaluationInProgress.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.EvaluationInProgress.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.WaitList.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.WaitList.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.Withdraw.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.Withdraw.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.Reject.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.Reject.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.MoveToAlumni.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.MoveToAlumni.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name =  SchoolStatus.Draft.Description(),
                            Count = _schools.Count(x => x.Status != null && string.Equals(x.Status, SchoolStatus.Draft.Description(), StringComparison.OrdinalIgnoreCase))
                        }
                    }
            });
            _summaries.Add(SummaryType.SchoolInterviews, new SummaryItemResult()
            {
                NeedAttentionCount = 0,
                Overviews = new List<OverviewItemResult>()
                    {
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.Completed.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.Completed.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.NotNeeded.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.NotNeeded.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.Required.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.Required.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.SchedulingInProgress.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.SchedulingInProgress.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.Scheduled.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.Scheduled.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.TBD.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && x.Status != SchoolStatus.Draft.Description()
                            && string.Equals(x.InterviewStatus, SchoolInterviewStatus.TBD.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.Upcoming.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.Upcoming.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = SchoolInterviewStatus.NotRequired.Description(),
                            Count = _schools.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, SchoolInterviewStatus.NotRequired.Description(), StringComparison.OrdinalIgnoreCase))
                        }
                    }
            });

            return this;
        }

        public IDashboardResponseBuilder SetVolunteerSummaries()
        {
            _summaries.Add(SummaryType.VolunteerApplications, new SummaryItemResult()
            {
                NeedAttentionCount = 0,
                Overviews = new List<OverviewItemResult>()
                    {
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.Draft.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null && string.Equals(x.VolunteerStatus, VolunteerStatus.Draft.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.Accept.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.Accept.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.Undecided.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.Undecided.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.EvaluationInProgress.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.EvaluationInProgress.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.Waitlist.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.Waitlist.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.Withdraw.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.Withdraw.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.Reject.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.Reject.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerStatus.MoveToAlumni.Description(),
                            Count = _volunteers.Count(x => x.VolunteerStatus != null &&string.Equals(x.VolunteerStatus, VolunteerStatus.MoveToAlumni.Description(), StringComparison.OrdinalIgnoreCase))
                        }
                    }
            });
            _summaries.Add(SummaryType.VolunteerInterviews, new SummaryItemResult()
            {
                NeedAttentionCount = 0,
                Overviews = new List<OverviewItemResult>()
                    {
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.TBD.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.TBD.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.Required.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.Required.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.Upcoming.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.Upcoming.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.SchedulingInProgress.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.SchedulingInProgress.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.Scheduled.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.Scheduled.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.Completed.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.Completed.Description(), StringComparison.OrdinalIgnoreCase))
                        },
                        new OverviewItemResult()
                        {
                            Name = VolunteerInterviewStatus.NotNeeded.Description(),
                            Count = _volunteers.Count(x => x.InterviewStatus != null && string.Equals(x.InterviewStatus, VolunteerInterviewStatus.NotNeeded.Description(), StringComparison.OrdinalIgnoreCase))
                        }
                    }
            });

            return this;
        }

        public IDashboardResponseBuilder WithSchools(IEnumerable<SchoolIndexModel> schools)
        {
            _schools = schools;
            return this;
        }

        public IDashboardResponseBuilder WithVolunteers(IEnumerable<VolunteerIndexModel> volunteers)
        {
            _volunteers = volunteers;
            return this;
        }

        public IDashboardResponseBuilder WithClasses(IEnumerable<ClassItemIndexModel> classDetails)
        {
            _classes = classDetails;
            return this;
        }
    }
}

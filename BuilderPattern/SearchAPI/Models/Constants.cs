namespace SearchAPI.Models
{
    public class Constants
    {
        public static class SearchIndexNames
        {
            public const string Volunteer = "volunteers";
            public const string VolunteerDetails = "volunteerdetails";
            public const string Schools = "schools";
            public const string SchoolDetails = "schooldetails";
        }

        public static class ErrorMessage
        {
            public const string Error_UnknownException = "Something unexpected happened. Please try again later.";
            public const string USER_NOT_FOUND = "User not found!";
            public const string VALIDATION_FAILED = "Validation failed!";
            public const string RECORD_NOT_FOUND = "Record not found!";
            public const string RECORD_EXISTS = "Similar record already exists!";
        }

        public static class ConfigKeys
        {
            public const string IdaTenant = nameof(IdaTenant);
            public const string IdaAudience = nameof(IdaAudience);
            public const string AuthorityDomain = nameof(AuthorityDomain);
            public const string AllowedOrigins = nameof(AllowedOrigins);
            public const string SearchServiceName = "";
            public const string SearchServiceEndpoint = "";
            public const string SearchAdminApiKey = "";
            public const string SearchQueryApiKey = "";
            public const string ServiceBusConnectionString = nameof(ServiceBusConnectionString);
            public const string BingApiLocations = nameof(BingApiLocations);
            public const string BingApiRoutes = nameof(BingApiRoutes);
            public const string BingMapsKey = nameof(BingMapsKey);
        }

        public static class ErrorCode
        {
            public const string UnAuthorized = nameof(UnAuthorized);
            public const string InvalidArgument = nameof(InvalidArgument);
            public const string DocumentNotFound = nameof(DocumentNotFound);
            public const string InvalidOperation = nameof(InvalidOperation);
            public const string Unknown = nameof(Unknown);
        }
    }
}

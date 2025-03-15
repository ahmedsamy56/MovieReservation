namespace MovieReservation.Data.Routing
{
    public static class Router
    {
        public const string SignleRoute = "/{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class CategoryRouting
        {
            public const string Prefix = Rule + "Category";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
        }

        public static class MovieRouting
        {
            public const string Prefix = Rule + "Movie";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }

        public static class TheaterRouting
        {
            public const string Prefix = Rule + "Theater";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }

        public static class ShowtimeRouting
        {
            public const string Prefix = Rule + "Showtime";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }

        public static class AppUser
        {
            public const string Prefix = Rule + "AppUser";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit";
            public const string Delete = Prefix + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }

    }
}

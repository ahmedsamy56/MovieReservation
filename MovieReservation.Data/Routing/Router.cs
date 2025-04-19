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

        public static class ReservationRouting
        {
            public const string Prefix = Rule + "Reservation";
            public const string ValidateReservation = Prefix + "/ValidateReservation";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Delete = Prefix + "/{id}";
            public const string GetMyTicket = Prefix + "/GetMyTicket/{id}";
            public const string Paginated = Prefix + "/Paginated";
        }

        public static class AppUserRouting
        {
            public const string Prefix = Rule + "AppUser";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + SignleRoute;
            public const string Create = Prefix + "/Create";
            public const string Edit = Prefix + "/Edit-Current-User";
            public const string Delete = Prefix + "Delete-Current-User";
            public const string Paginated = Prefix + "/Paginated";
            public const string ChangePassword = Prefix + "/ChangePassword";
        }
        public static class AuthenticationRouting
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/Refresh-Token";
            public const string ValidateToken = Prefix + "/Validate-Token";
            public const string ConfirmEmail = Prefix + "/ConfirmEmail";
        }


        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "Authorization";
            public const string AddAdminRole = Prefix + "/Add-User-To-Admin-Role";
            public const string RemoveAdminRole = Prefix + "/Remove-User-From-Admin-Role";
            public const string AllAdmins = Prefix + "/All-Admins";

        }

        public static class EmailsRoute
        {
            public const string Prefix = Rule + "EmailsRoute";
            public const string SendEmail = Prefix + "/SendEmail";
        }


    }
}

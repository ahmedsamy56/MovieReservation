namespace MovieReservation.Data.Results
{
    public class GetUserRoleRespons
    {
        public int UserId { get; set; }
        public List<UserRoles> userRoles { get; set; }
    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

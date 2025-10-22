namespace ITI.MVC.PL.Dto
{
    public class UserRoleDto
    {
        public string Id { get; set; }
        public string userName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IEnumerable<string>? Roles { get; set; }
    }
}

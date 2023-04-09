namespace project_basic_Authentication.Models
{
    public class UserProgram
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    

        public string[] Roles { get; set; }
    }
}

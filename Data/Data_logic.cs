using project_basic_Authentication.Models;

namespace project_basic_Authentication.Data
{
    public class Data_logic
    {
        public List<UserProgram> ListUsers()
        {
            return new List<UserProgram>
            {
                new UserProgram{Name="Juan", Email= "Admin@mail.com", Password = "123", Roles = new string[] {"Admin" } },
                new UserProgram{Name="maria", Email= "Superviser@mail.com", Password = "123", Roles = new string[] {"Superviser" } },
                new UserProgram{Name="Jose", Email= "Employee@mail.com", Password = "123", Roles = new string[] {"employee" } },
                new UserProgram{Name="Jorge", Email= "SuperEmployee@mail.com", Password = "123", Roles = new string[] {"employee", "Superviser" } },
            };
        }


        public UserProgram ValidateUser(string mail, string password)
        {
            return ListUsers().Where(item => item.Email == mail && item.Password == password).FirstOrDefault();
        }
    }
}

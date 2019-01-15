using System;

namespace ClassLibrary
{
    public class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public User(string username, string firstname, string lastname, DateTime birthdate)
        {
            UserName = username;
            FirstName = firstname;
            LastName = lastname;
            BirthDate = birthdate;
        }
    }
}

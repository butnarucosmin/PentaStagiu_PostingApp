using System;

namespace ClassLibrary
{
    public class User
    {
        public string UserName;
        private string FirstName;
        private string LastName;
        private DateTime BirthDate;

        public User(string username, string firstname, string lastname, DateTime birthdate)
        {
            this.UserName = username;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.BirthDate = birthdate;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class UserService
    {
        private List<User> users = new List<User>();

        public User AddUser(string username, string firstname, string lastname, DateTime birthdate)
        {
            User user = new User(username, firstname, lastname, birthdate);
            this.users.Add(user);
            return user;
        }

        public List<User> GetUsers()
        {
            return this.users;
        }
    }
}

using System;

namespace ClassLibrary
{
    public class Post
    {
        public string UserName;
        public string Message;
        public DateTime Time;

        public Post(string username, string message, DateTime time)
        {
            this.UserName = username;
            this.Message = message;
            this.Time = time;
        }
    }
}

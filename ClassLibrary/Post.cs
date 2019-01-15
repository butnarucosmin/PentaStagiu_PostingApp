using System;

namespace ClassLibrary
{
    public class Post
    {
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime Time { get; set; }

        public Post(string username, string message, DateTime time)
        {
            UserName = username;
            Message = message;
            Time = time;
        }
    }
}

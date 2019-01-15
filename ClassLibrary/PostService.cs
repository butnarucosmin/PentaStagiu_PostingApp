using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class PostService
    {
        public event EventHandler PostAdded;

        private List<Post> posts = new List<Post>();        

        public Post AddPost(string username, string message, DateTime time)
        {
            Post post = new Post(username, message, time);
            posts.Add(post);
            OnPostAdded();
            return post;
        }

        public List<Post> GetPosts()
        {
            return posts;
        }

        public Post this[int index]
        {
            get
            {
                return posts[index];
            }
            set
            {
                posts[index] = value;
            }
        }

        private void OnPostAdded()
        {
            PostAdded?.Invoke(this, EventArgs.Empty);
        }
    }
}

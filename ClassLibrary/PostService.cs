using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class PostService
    {
        private List<Post> posts = new List<Post>();

        public Post AddPost(string username, string message, DateTime time)
        {
            Post post = new Post(username, message, time);
            this.posts.Add(post);
            return post;
        }

        public List<Post> GetPosts()
        {
            return this.posts;
        }
    }
}

using System;

namespace csharp_intermediate_exercises
{
    public class Post
    {
        public string Title
        {
            get;
        }
        public string Description
        {
            get;
        }
        public DateTime Created
        {
            get;
        }
        public int Votes
        {
            get;
            private set;
        }

        public Post(string title, string description)
        {
            Votes = 0;
            this.Title = title;
            this.Description = description;
            Created = DateTime.Now;
        }

        public void UpVote()
        {
            Votes++;
        }

        public void DownVote()
        {
            Votes--;
        }

    }
}

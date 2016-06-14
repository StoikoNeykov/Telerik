namespace School.Models
{
    using System;

    using Interfaces;

    public abstract class People : ICommentable
    {
        private string name;

        private string comment;

        public People(string name)
        {
            this.Name = name;
        }

        public string Comment
        {
            get
            {
                if (string.IsNullOrEmpty(this.comment))
                {
                    return "No comments available";
                }

                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Invalid name!");
                }

                this.name = value;
            }
        }
    }
}

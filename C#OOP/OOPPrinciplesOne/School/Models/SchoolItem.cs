namespace School.Models
{
    using System;

    using Interfaces;

    /// <summary>
    /// Each of school classes have name. Not person classes parent
    /// </summary>
    public abstract class SchoolItem : ICommentable
    {
        private string ident;

        private string comment;

        public SchoolItem(string name)
        {
            this.Ident = name;
        }

        public string Ident
        {
            get
            {
                return this.ident;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name have to be set!");
                }

                this.ident = value;
            }
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
    }
}

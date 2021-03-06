﻿namespace DefineClass
{
    using System;

    /// <summary>
    /// Every call is a object. Duration is TimeSpan
    /// </summary>
    public class Call
    {
        private DateTime dateTime;

        private string contact;

        private TimeSpan duration;

        public Call(DateTime dateTime, string contact, int seconds)
        {
            this.DateTime = dateTime;
            this.Contact = contact;
            this.Duration = new TimeSpan(0, 0, seconds);
        }

        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }

            private set
            {
                this.dateTime = value;
            }
        }

        public string Contact
        {
            get
            {
                return contact;
            }
            private set
            {
                this.contact = value;
            }
        }

        public TimeSpan Duration
        {
            get
            {
                return this.duration;
            }
            private set
            {
                if (value < TimeSpan.Zero)
                {
                    throw new ArgumentException("Call cannot have negative duration!");
                }
                this.duration = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}  {2}",
                this.dateTime.ToString(@"dd/mm/yy h\:mm\:ss"),
                this.contact.PadRight(15, ' '),
                this.duration.ToString(@"mm\:ss"));
        }

        // in real life you cant have 2 calls with same person in same time 
        public bool Equals(Call targetCall)
        {
            if (this.DateTime == targetCall.DateTime && this.Contact == targetCall.Contact)
            {
                return true;
            }

            return false;
        }
    }
}

using System;

namespace Methods
{
    public class Student
    {
        private string firstName;

        private string lastName;

        private DateTime dateOfBirth;

        private string info;

        private Student(string firstname, string lastNamem, string info)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Info = info;
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string info = "")
            : this(firstName, lastName, info)
        {
            this.DateOfBirth = dateOfBirth;
        }

        public Student(string firstName, string lastName, string dateOfBirth, string info = "")
            : this(firstName, lastName, info)
        {
            this.DateOfBirth = DateTimeParse(dateOfBirth);
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.IsNullOrEmptyError,
                                                                "FirstName"));
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(string.Format(GlobalConstants.IsNullOrEmptyError, 
                                                                "LastName"));
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }
            private set
            {
                if (IsValidDateOfBirth(value, DateTime.Today))
                {
                    this.dateOfBirth = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("DateOfBirth");
                }
            }
        }

        public string Info
        {
            get
            {
                return this.info;
            }
            // its optional parameter and not rly need to be private - expecting changes to be fine here
            // catching null only
            set
            {
                this.info = value == null ? "" : value;
            }
        }

        private DateTime DateTimeParse(string date)
        {
            DateTime parsedDate;
            bool success = DateTime.TryParse(date, out parsedDate);

            if (!success)
            {
                throw new ArgumentException(string.Format(GlobalConstants.InvalidParameterError, 
                                                            "dateOfBirth"));
            }

            return parsedDate;
        }

        // Method should be private but can me change to internal for testing
        private bool IsValidDateOfBirth(DateTime dateOfBirth, DateTime now)
        {
            int age = now.Year - dateOfBirth.Year;

            if (now < dateOfBirth.AddYears(age))
            {
                age--;
            }

            if (GlobalConstants.MinmumStudentAge <= age && age <= GlobalConstants.MaximumStudentAge)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // cahnged > to < coz if this is > then other then "this" born later and actually yonger! 
        public bool IsOlderThan(Student other)
        {
            return this.dateOfBirth < other.dateOfBirth;
        }
    }
}

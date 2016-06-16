namespace Student.Models
{
    using System;
    using System.Linq;
    using System.Text;

    using Enumerations;

    /// <summary>
    /// Class student with overrides for base method and added operators
    /// </summary>
    public class Student : ICloneable, IComparable<Student>
    {
        private string firstName;

        private string middleName;

        private string lastName;

        private string ssn;

        private string address;

        private string phone;

        private string mail;

        private string course;

        private Specialties speciality;

        private Faculties faculty;

        private University university;

        public Student(string firstName, string middleName, string lastName, string ssn, string address,
            string phone, string mail, string course, Specialties speciality, Faculties faculty,
            University university)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.Phone = phone;
            this.Mail = mail;
            this.Course = course;
            this.Speciality = speciality;
            this.Faculty = faculty;
            this.University = university;
        }

        private Student(Student stud)
            : this(stud.FirstName, stud.MiddleName, stud.LastName, stud.SSN, stud.Address, stud.Phone,
                 stud.Mail, stud.Course, stud.Speciality, stud.Faculty, stud.University)
        {

        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                ValidateName(value);
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                ValidateName(value);
                this.middleName = value;
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
                ValidateName(value);
                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                ValidateSSN(value);
                this.ssn = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        public string Mail
        {
            get
            {
                return this.mail;
            }
            set
            {
                this.mail = value;
            }
        }

        public string Course
        {
            get
            {
                return this.course;
            }
            set
            {
                this.course = value;
            }
        }

        public Specialties Speciality
        {
            get
            {
                return this.speciality;
            }
            set
            {
                this.speciality = value;
            }
        }

        public Faculties Faculty
        {
            get
            {
                return this.faculty;
            }
            set
            {
                this.faculty = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }
            set
            {
                this.university = value;
            }
        }

        private void ValidateSSN(string ssn)
        {
            if (ssn.Length != 9 && ssn.Length != 11)
            {
                throw new ArgumentException("Invalid SSN!");
            }

            if (ssn.Length == 9)
            {
                try
                {
                    var result = int.Parse(ssn);
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Invalid SSN!", ex);
                }

            }
            else // 11 symbols
            {
                try
                {
                    var result = ssn.Split('-').Select(int.Parse);
                }
                catch (Exception ex)
                {

                    throw new ArgumentException("Invalid SSN!", ex);
                }

            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name have to be set!");
            }

            foreach (var ch in name)
            {
                if (!char.IsLetter(ch))
                {
                    throw new ArgumentException("Invalid name!");
                }
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(string.Format("{0} {1} {2}",
                this.FirstName,
                this.MiddleName,
                this.LastName));
            builder.AppendLine(string.Format("SSN: {0}", this.SSN));
            builder.AppendLine(string.Format("Phone: {0} Mail: {1}",
                this.Phone,
                this.Mail));
            builder.AppendLine(string.Format("Address: {0}:", this.Address));
            builder.AppendLine(string.Format("Course: {0}:", this.Course));
            builder.AppendLine(string.Format("Speciality: {0}", this.Speciality));
            builder.AppendLine(string.Format("Faculty: {0}", this.Faculty));
            builder.AppendLine(string.Format("University: {0}", this.University));

            return builder.ToString();
        }

        public override bool Equals(object student)
        {
            if (!(student is Student))
            {
                return false;
            }

            var other = student as Student;
            if (this.FirstName != other.FirstName
                || this.MiddleName != other.MiddleName
                || this.LastName != other.LastName
                || this.SSN != other.SSN
                || this.Phone != other.Phone
                || this.Mail != other.Mail
                || this.Address != other.Address
                || this.Course != other.Course
                || this.Speciality != other.Speciality
                || this.Faculty != other.Faculty
                || this.University != other.University)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = 31 * hash + this.SSN.GetHashCode();
            hash = 31 * hash + this.Mail.GetHashCode();
            hash = 31 * hash + this.Course.GetHashCode();

            return hash;
        }

        public static bool operator ==(Student first, Student second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
            {
                return true;
            }

            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
            {
                return false;
            }

            return first.Equals(second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !(first == second);
        }

        public object Clone()
        {
            return new Student(this);
        }

        public int CompareTo(Student other)
        {
            if (this.firstName != other.firstName)
            {
                return this.firstName.CompareTo(other.firstName);
            }
            else if (this.middleName != other.middleName)
            {
                return this.middleName.CompareTo(other.middleName);
            }
            else if (this.lastName != other.lastName)
            {
                return this.lastName.CompareTo(other.lastName);
            }
            else
            {
                return this.ssn.CompareTo(other.ssn);
            }
        }
    }
}

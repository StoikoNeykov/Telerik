namespace Person.Models
{
    /// <summary>
    /// Problem 4. 
    /// </summary>
    public class Person
    {
        private string name;

        private int? age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} Age: {1}", this.Name, this.Age == null ? "none" : this.Age.ToString());
        }
    }
}

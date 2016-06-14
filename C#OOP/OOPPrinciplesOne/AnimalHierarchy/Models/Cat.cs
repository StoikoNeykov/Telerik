namespace AnimalHierarchy.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Cats are usually very playful. Parent class for Kitty and Tomcat
    /// </summary>
    public class Cat : Animal, ISound
    {
        public Cat(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public string Play(int random)
        {
            if (random < 3)
            {
                return string.Format("{0} is sleeping! Unavilable to play.", this.Name);
            }

            return string.Format("{0} is very playful!", this.Name);
        }

        public override string Sound()
        {
            return "Meow!";
        }
    }
}

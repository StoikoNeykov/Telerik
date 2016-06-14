namespace AnimalHierarchy.Models
{
    using System;

    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Dogs likes to follow the stick. Young dogs are not very good at the!
    /// </summary>
    public class Dog : Animal, ISound
    {
        public Dog(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public string FollowTheStick(int random)
        {
            if (this.Age<1)
            {
                return string.Format("{0} is too young to find the stick. Need more practice!", this.Name);
            }

            if (random < 2)
            {
                return string.Format("{0} coudnt find the stick! Now the stick is lost.", this.Name);
            }

            return string.Format("{0} running back with the stick! Good boy!", this.Name);
        }

        public override string Sound()
        {
            return "Bau!";
        }
    }
}

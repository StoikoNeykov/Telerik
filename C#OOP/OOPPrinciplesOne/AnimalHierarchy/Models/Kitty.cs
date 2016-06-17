namespace AnimalHierarchy.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Its a cat. Always female
    /// </summary>
    public class Kitty : Cat, ISound
    {
        public Kitty(string name, int age) 
            : base(name, age, Gender.Female)
        {
        }

        public override string Sound()
        {
            return "Mew!";
        }
    }
}

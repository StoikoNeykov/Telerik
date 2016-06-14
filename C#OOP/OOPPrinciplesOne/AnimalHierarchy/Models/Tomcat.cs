namespace AnimalHierarchy.Models
{
    using Enumerations;
    using Interfaces;

    /// <summary>
    /// Its a cat. Always male
    /// </summary>
    public class Tomcat : Cat, ISound
    {
        public Tomcat(string name, int age) 
            : base(name, age, SexType.Male)
        {
        }

        public override string Sound()
        {
            return "Meu!";
        }
    }
}

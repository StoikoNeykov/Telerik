using HumanMaker.Enumerations;
using HumanMaker.Models;

namespace HumanMaker
{
    public class StartUp
    {
        public static void Main(int age)
        {
            var person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Батката";
                person.Gender = Gender.Male;
            }
            else
            {
                person.Name = "Мацето";
                person.Gender = Gender.Female;
            }
        }
    }
}

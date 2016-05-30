namespace IntrodusingToPrograming
{
    /// <summary>
    /// Program read birthday from console and return age after 10 years
    /// </summary>
    using System;

    public class Age
    {
        public static void Main()
        {
            var bday = DateTime.Parse(Console.ReadLine());
            int age = DateTime.Now.Year - bday.Year;
            if (DateTime.Now.Month < bday.Month || (DateTime.Now.Month == bday.Month && DateTime.Now.Day < bday.Day))
            {
                age--; 
            }
            Console.WriteLine(age);
            Console.WriteLine(age + 10);
        }
    }
}
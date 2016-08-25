namespace Bunnies
{
    using System.Collections.Generic;
    using System.IO;

    using Contracts;
    using Enumerations;
    using Models;
    using Workers;

    public class Bunnies
    {
        private const string BunniesFilePath = @"..\..\bunnies.txt";

        public static void Main()
        {
            var bunnies = GetBunniesList();

            var consoleWriter = new ConsoleWriter();
            IntroduceAllBunnies(consoleWriter, bunnies);

            if (!File.Exists(BunniesFilePath))
            {
                CreateBunniesFile(BunniesFilePath);
            }

            var streamWriter = new StreamWriter(BunniesFilePath);
            SaveBunnies((IStreamWriter)streamWriter, bunnies);
        }

        private static IList<IBunny> GetBunniesList()
        {
            return new List<IBunny>
            {
                new Bunny("Leonid", 1, FurType.NotFluffy),
                new Bunny("Rasputin", 2, FurType.ALittleFluffy),
                new Bunny("Tiberii", 3, FurType.ALittleFluffy),
                new Bunny("Neron", 1, FurType.ALittleFluffy),
                new Bunny("Klavdii", 3, FurType.Fluffy),
                new Bunny("Vespasian", 3, FurType.Fluffy),
                new Bunny("Domician", 4, FurType.FluffyToTheLimit),
                new Bunny("Tit", 2, FurType.FluffyToTheLimit)
            };
        }

        private static void IntroduceAllBunnies(IWriter writer, IList<IBunny> bunnies)
        {
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(writer);
            }
        }

        private static void CreateBunniesFile(string filePath)
        {
            File.Create(filePath).Close();
        }

        private static void SaveBunnies(IStreamWriter streamWriter, IList<IBunny> bunnies)
        {
            using (streamWriter)
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }
}

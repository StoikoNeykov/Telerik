namespace Bunnies.Models
{
    using System;
    using System.Text;

    using Contracts;
    using Enumerations;
    using Extensions;

    [Serializable]
    public class Bunny : IBunny
    {
        private int age;

        public Bunny()
        {
            this.Name = string.Empty;
            this.Age = 0;
            this.FurType = FurType.NotFluffy;
        }

        public Bunny(string name, int age, FurType furType)
        {
            this.Name = name;
            this.Age = age;
            this.FurType = furType;
        }

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("BunnyAge", "Bunny age cannot be negative!");
                }

                this.age = value;
            }
        }

        public FurType FurType { get; set; }

        public void Introduce(IWriter writer)
        {
            var furString = this.FurType
                                .ToString()
                                .SplitToSeparateWordsByUppercaseLetter();

            writer.WriteLine($"{this.Name} - \"I am {this.Age} years old!\"");
            writer.WriteLine($"{this.Name} - \"And I am {furString}");
        }

        public override string ToString()
        {
            var builderSize = 200;
            var builder = new StringBuilder(builderSize);
            var furString = this.FurType
                                .ToString()
                                .SplitToSeparateWordsByUppercaseLetter();

            builder.AppendLine($"Bunny name: {this.Name}");
            builder.AppendLine($"Bunny age: {this.Age}");
            builder.AppendLine($"Bunny fur: {furString}");

            return builder.ToString();
        }
    }
}

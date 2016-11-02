using System;
using Visitor.Visitors;

namespace Visitor
{
    class Startup
    {
        static void Main()
        {
            var profile = new SocialMediaProfile("Niki");

            var creeper = new Creeper();
            profile.Accept(creeper);
            Console.WriteLine(profile);

            var stalker = new Stalker();
            profile.Accept(stalker);
            Console.WriteLine(profile);
        }
    }
}

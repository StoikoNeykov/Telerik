namespace IntergalacticTravel.Tests
{
    using NUnit.Framework;

    using IntergalacticTravel;
    using IntergalacticTravel.Exceptions;

    [TestFixture]
    public class UnitsFactoryTests
    {
        [Test]
        public void GetUnit_ShouldReturnProcyon_WhenValidCorrespondingCommandIsPassed()
        {
            var validCommand = "create unit Procyon Gosho 1";

            var factory = new UnitsFactory();

            var result = factory.GetUnit(validCommand);

            Assert.IsInstanceOf<Procyon>(result);
        }

        [Test]
        public void GetUnit_ShouldReturnLuyten_WhenValidCorrespondingCommandIsPassed()
        {
            var validCommand = "create unit Luyten Pesho 2";

            var factory = new UnitsFactory();

            var result = factory.GetUnit(validCommand);

            Assert.IsInstanceOf<Luyten>(result);
        }

        [Test]
        public void GetUnit_ShouldReturnLacaille_WhenValidCorrespondingCommandIsPassed()
        {
            var validCommand = "create unit Lacaille Tosho 3";

            var factory = new UnitsFactory();

            var result = factory.GetUnit(validCommand);

            Assert.IsInstanceOf<Lacaille>(result);
        }

        [TestCase("Invalid string format and expecting to throw the proper exception")]
        [TestCase("Just another totally invalid string ... can you imagine")]
        public void GetUnit_ShouldThrowInvalidUnitCreationCommandException_WhenInvalidStringPassed(string invalidString)
        {
            var factory = new UnitsFactory();

            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(invalidString));
        }
    }
}

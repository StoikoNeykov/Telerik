namespace IntergalacticTravel.Tests.UnitTests
{
    using System;

    using NUnit.Framework;
    using Telerik.JustMock;

    using IntergalacticTravel;
    using IntergalacticTravel.Contracts;

    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_ShouldThrowNullReferenceException_IfPassedObjectIsNull()
        {
            var anyId = 18;
            var anyName = "TheUnitName";

            var unit = new Unit(anyId, anyName);

            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }


        [Test]
        public void Pay_ShouldDecreaseUnitResurces_WithAmountOfTheCost()
        {
            uint hardcodedGold = 10;
            uint hardcodedSilver = 8;
            uint hardcodedBronze = 1;

            var anyId = 18;
            var anyName = "TheUnitName";

            var mockedCost = Mock.Create<IResources>();
            Mock.Arrange(() => mockedCost.BronzeCoins).Returns(hardcodedBronze);
            Mock.Arrange(() => mockedCost.SilverCoins).Returns(hardcodedSilver);
            Mock.Arrange(() => mockedCost.GoldCoins).Returns(hardcodedGold);

            var unit = new Unit(anyId, anyName);

            var mockedresurces = Mock.Create<IResources>();
            Mock.Arrange(() => mockedresurces.BronzeCoins).Returns(100);
            Mock.Arrange(() => mockedresurces.SilverCoins).Returns(100);
            Mock.Arrange(() => mockedresurces.GoldCoins).Returns(100);

            unit.Resources.Add(mockedresurces);

            unit.Pay(mockedCost);

            Assert.AreEqual(100 - hardcodedGold, unit.Resources.GoldCoins);
            Assert.AreEqual(100 - hardcodedSilver, unit.Resources.SilverCoins);
            Assert.AreEqual(100 - hardcodedBronze, unit.Resources.BronzeCoins);
        }

        [Test]
        public void Pay_ShouldReturnResourceObject_WithTheAmountOfResourcesInTheCostObject()
        {
            uint hardcodedGold = 10;
            uint hardcodedSilver = 8;
            uint hardcodedBronze = 1;

            var anyId = 18;
            var anyName = "TheUnitName";

            var mockedCost = Mock.Create<IResources>();
            Mock.Arrange(() => mockedCost.BronzeCoins).Returns(hardcodedBronze);
            Mock.Arrange(() => mockedCost.SilverCoins).Returns(hardcodedSilver);
            Mock.Arrange(() => mockedCost.GoldCoins).Returns(hardcodedGold);

            var unit = new Unit(anyId, anyName);

            var result = unit.Pay(mockedCost);

            Assert.AreEqual(hardcodedGold, result.GoldCoins);
            Assert.AreEqual(hardcodedSilver, result.SilverCoins);
            Assert.AreEqual(hardcodedBronze, result.BronzeCoins);

        }
    }
}

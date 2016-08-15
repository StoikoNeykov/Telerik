namespace IntergalacticTravel.Tests
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using Telerik.JustMock;

    using IntergalacticTravel;
    using IntergalacticTravel.Contracts;

    [TestFixture]
    public class BusinessOwnerTests
    {
        [Test]
        public void CollectProfit_ShouldIncreaseOwnerResurses()
        {
            var anyname = "ownerName";
            int anyId = 5002;
            var tpStationList = new List<ITeleportStation>();

            uint expectedBronze = 10;
            uint expectedSilver = 20;
            uint expectedGold = 30;

            var mockedresurces = Mock.Create<IResources>();
            Mock.Arrange(() => mockedresurces.BronzeCoins).Returns(expectedBronze);
            Mock.Arrange(() => mockedresurces.SilverCoins).Returns(expectedSilver);
            Mock.Arrange(() => mockedresurces.GoldCoins).Returns(expectedGold);

            var mockedTeleportStartion = Mock.Create<ITeleportStation>();
            Mock.Arrange(() => mockedTeleportStartion.PayProfits(Arg.IsAny<IBusinessOwner>())).Returns(mockedresurces);

            tpStationList.Add(mockedTeleportStartion);

            var owner = new BusinessOwner(anyId, anyname, tpStationList);

            owner.CollectProfits();

            Assert.AreEqual(expectedBronze, owner.Resources.BronzeCoins);
            Assert.AreEqual(expectedSilver, owner.Resources.SilverCoins);
            Assert.AreEqual(expectedGold, owner.Resources.GoldCoins);
        }
    }
}

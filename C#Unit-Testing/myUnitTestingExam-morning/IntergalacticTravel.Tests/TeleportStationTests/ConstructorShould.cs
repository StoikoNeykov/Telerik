namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System.Collections.Generic;

    using NUnit.Framework;
    using Telerik.JustMock;

    using IntergalacticTravel;
    using IntergalacticTravel.Contracts;

    [TestFixture]
    public class ConstructorShould
    {
        // 3 tests actually represent 1 test from descripttion.
        // Looks simular but testing diferent things so i decide to split them
        [Test]
        public void ProperlySetOwner_WhenNewTeleportStationIsCreatedWithValidParameters()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedLocation = Mock.Create<ILocation>();
            var emptyListOfPaths = new List<IPath>();

            var station = new TeleportStationKid(mockedOwner, emptyListOfPaths, mockedLocation);

            Assert.AreSame(mockedOwner, station.Owner);
        }

        [Test]
        public void ProperlySetgalacticMap_WhenNewTeleportStationIsCreatedWithValidParameters()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedLocation = Mock.Create<ILocation>();
            var emptyListOfPaths = new List<IPath>();

            var station = new TeleportStationKid(mockedOwner, emptyListOfPaths, mockedLocation);

            Assert.AreSame(emptyListOfPaths, station.GalacticMap);
        }

        [Test]
        public void ProperlySetLocation_WhenNewTeleportStationIsCreatedWithValidParameters()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedLocation = Mock.Create<ILocation>();
            var emptyListOfPaths = new List<IPath>();

            var station = new TeleportStationKid(mockedOwner, emptyListOfPaths, mockedLocation);

            Assert.AreSame(mockedLocation, station.Location);
        }
    }
}

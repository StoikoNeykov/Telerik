namespace IntergalacticTravel.Tests.TeleportStationTests
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Telerik.JustMock;

    using IntergalacticTravel.Contracts;
    using IntergalacticTravel.Exceptions;

    [TestFixture]
    public class TeleportUnitShould
    {
        [Test]
        public void ThrowArgumentNullException_IFUnitToTeleportIsNull()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedLocation = Mock.Create<ILocation>();
            var emptyListOfPaths = new List<IPath>();

            var mockedTargetLocation = Mock.Create<ILocation>();

            var station = new TeleportStation(mockedOwner, emptyListOfPaths, mockedLocation);

            Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(null, mockedTargetLocation));
        }

        [Test]
        public void ThrowArgumentNullException_IFTargetLocationIsNull()
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var mockedLocation = Mock.Create<ILocation>();
            var emptyListOfPaths = new List<IPath>();

            var mockedUnitToTeleport = Mock.Create<IUnit>();

            var station = new TeleportStation(mockedOwner, emptyListOfPaths, mockedLocation);

            Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(mockedUnitToTeleport, null));
        }


        [TestCase("1", "2", "1", "1")]
        [TestCase("1", "1", "2", "1")]
        [TestCase("2", "2", "2", "1")]
        [TestCase("2", "1", "2", "2")]
        public void ThrowTeleportOutOfRangeException_WithSpecificStringMsg_WhenUnitTOTeleportUsingTeleportStation_FromDistantLocation(string galaxyName1,
                                                                                                                                        string galaxyName2,
                                                                                                                                        string plannetName1,
                                                                                                                                        string plannetName2)
        {
            var mockedOwner = Mock.Create<IBusinessOwner>();
            var ListOfPaths = new List<IPath>();
            var mockedStationLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedStationLocation.Coordinates).Returns(Mock.Create<IGPSCoordinates>());
            var stationPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => stationPlanet.Galaxy.Name).Returns(galaxyName1);
            Mock.Arrange(() => stationPlanet.Name).Returns(plannetName1);

            Mock.Arrange(() => mockedStationLocation.Planet).Returns(stationPlanet);

            var unitMockedLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => unitMockedLocation.Coordinates).Returns(Mock.Create<IGPSCoordinates>());
            var unitPlannet = Mock.Create<IPlanet>();
            Mock.Arrange(() => unitPlannet.Galaxy.Name).Returns(galaxyName2);
            Mock.Arrange(() => unitPlannet.Name).Returns(plannetName2);

            Mock.Arrange(() => unitMockedLocation.Planet).Returns(unitPlannet);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation).Returns(unitMockedLocation);

            var targetLocation = Mock.Create<ILocation>();
            var mockedPath = Mock.Create<IPath>();
            Mock.Arrange(() => mockedPath.TargetLocation).Returns(targetLocation);
            Mock.Arrange(() => mockedPath.Cost).Returns(Mock.Create<IResources>());

            ListOfPaths.Add(mockedPath);

            var station = new TeleportStation(mockedOwner, ListOfPaths, mockedStationLocation);

            var expectedExceptionMsg = "unitToTeleport.CurrentLocation";
            var result = string.Empty;

            try
            {
                station.TeleportUnit(mockedUnitToTeleport, targetLocation);
            }
            catch (TeleportOutOfRangeException ex)
            {
                result = ex.Message;
            }

            StringAssert.Contains(expectedExceptionMsg, result);
        }

        [Test]
        public void ThrowInvalidTeleportationLocationException_WithMsgContainsSpecific_WhenTryingToTeleportToAlreadyTakenLocation()
        {
            var targetLocationName = "someRandomString";
            var targetLocationGalaxyName = "JustAnotherRandomString";
            var curentLocationName = "namename";
            var curentGalaxyName = "galaxyname";

            var mockedOwner = Mock.Create<IBusinessOwner>();
            var stationListOfPaths = new List<IPath>();
            var mockedStationLocation = Mock.Create<ILocation>();

            Mock.Arrange(() => mockedStationLocation.Coordinates).Returns(Mock.Create<IGPSCoordinates>());
            var stationPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => stationPlanet.Galaxy.Name).Returns(curentGalaxyName);
            Mock.Arrange(() => stationPlanet.Name).Returns(curentLocationName);

            Mock.Arrange(() => mockedStationLocation.Planet).Returns(stationPlanet);


            var mockedTargetLocation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedTargetLocation.Planet.Galaxy.Name).Returns(targetLocationGalaxyName);
            Mock.Arrange(() => mockedTargetLocation.Planet.Name).Returns(targetLocationName);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation).Returns(mockedStationLocation);

            var mockedUnitThatOcupateTargetLocation = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnitThatOcupateTargetLocation.CurrentLocation).Returns(mockedTargetLocation);

            var fakeCollectionThatContainsTheUnit = new List<IUnit>();
            fakeCollectionThatContainsTheUnit.Add(mockedUnitThatOcupateTargetLocation);

            Mock.Arrange(() => mockedTargetLocation.Planet.Units).Returns(fakeCollectionThatContainsTheUnit);

            var mockedPath = Mock.Create<IPath>();
            Mock.Arrange(() => mockedPath.TargetLocation).Returns(mockedTargetLocation);
            Mock.Arrange(() => mockedPath.Cost).Returns(Mock.Create<IResources>());

            stationListOfPaths.Add(mockedPath);

            var station = new TeleportStation(mockedOwner, stationListOfPaths, mockedStationLocation);

            var expectedMsg = "units will overlap";
            var result = string.Empty;

            try
            {
                station.TeleportUnit(mockedUnitToTeleport, mockedTargetLocation);
            }
            catch (InvalidTeleportationLocationException ex)
            {
                result = ex.Message;
            }

            StringAssert.Contains(expectedMsg, result);
        }

        [Test]
        public void ThrowLocationNotFoundException_WithMsgThatContainstGalaxy_WhenTryToTeleportToGalaxyThatIsNotInTheList()
        {
            var targetLocationName = "someRandomString";
            var targetLocationGalaxyName = "JustAnotherRandomString";
            var curentLocationName = "namename";
            var curentGalaxyName = "galaxyname";

            var mockedOwner = Mock.Create<IBusinessOwner>();
            var stationListOfPaths = new List<IPath>();
            var mockedStationLocation = Mock.Create<ILocation>();

            Mock.Arrange(() => mockedStationLocation.Coordinates).Returns(Mock.Create<IGPSCoordinates>());
            var stationPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => stationPlanet.Galaxy.Name).Returns(curentGalaxyName);
            Mock.Arrange(() => stationPlanet.Name).Returns(curentLocationName);

            Mock.Arrange(() => mockedStationLocation.Planet).Returns(stationPlanet);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation).Returns(mockedStationLocation);

            var mockedTargetLovation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedTargetLovation.Planet.Name).Returns(targetLocationName);
            Mock.Arrange(() => mockedTargetLovation.Planet.Galaxy.Name).Returns(targetLocationGalaxyName);

            var station = new TeleportStation(mockedOwner, stationListOfPaths, mockedStationLocation);

            var expected = "Galaxy";
            var result = string.Empty;

            try
            {
                station.TeleportUnit(mockedUnitToTeleport, mockedTargetLovation);
            }
            catch (LocationNotFoundException ex)
            {
                result = ex.Message;
            }

            StringAssert.Contains(expected, result);
        }

        [Test]
        public void ThrowLocationNotFoundException_WithMsgThatContainstPlanet_WhenTryToTeleportToGalaxyThatIsNotInTheList()
        {
            var anotherPlanetName = "Casiopea";
            var targetLocationName = "someRandomString";
            var targetLocationGalaxyName = "JustAnotherRandomString";
            var curentLocationName = "namename";
            var curentGalaxyName = "galaxyname";

            var mockedOwner = Mock.Create<IBusinessOwner>();
            var stationListOfPaths = new List<IPath>();
            var mockedExsistedPath = Mock.Create<IPath>();
            Mock.Arrange(() => mockedExsistedPath.TargetLocation.Planet.Galaxy.Name).Returns(targetLocationGalaxyName);
            Mock.Arrange(() => mockedExsistedPath.TargetLocation.Planet.Name).Returns(anotherPlanetName);
            Mock.Arrange(() => mockedExsistedPath.Cost).Returns(Mock.Create<IResources>());

            stationListOfPaths.Add(mockedExsistedPath);

            var mockedStationLocation = Mock.Create<ILocation>();

            Mock.Arrange(() => mockedStationLocation.Coordinates).Returns(Mock.Create<IGPSCoordinates>());
            var stationPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => stationPlanet.Galaxy.Name).Returns(curentGalaxyName);
            Mock.Arrange(() => stationPlanet.Name).Returns(curentLocationName);

            Mock.Arrange(() => mockedStationLocation.Planet).Returns(stationPlanet);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation).Returns(mockedStationLocation);

            var mockedTargetLovation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedTargetLovation.Planet.Name).Returns(targetLocationName);
            Mock.Arrange(() => mockedTargetLovation.Planet.Galaxy.Name).Returns(targetLocationGalaxyName);

            var station = new TeleportStation(mockedOwner, stationListOfPaths, mockedStationLocation);

            var expected = "Planet";
            var result = string.Empty;

            try
            {
                station.TeleportUnit(mockedUnitToTeleport, mockedTargetLovation);
            }
            catch (LocationNotFoundException ex)
            {
                result = ex.Message;
            }

            StringAssert.Contains(expected, result);
        }

        [Test]
        public void ThrowInsufficientResourcesException_WithMsgThatContainsFREELUNCH_WhenTryingToTeleportWithNotEnoughResources()
        {
            uint expectedBronze = 10;
            uint expectedSilver = 20;
            uint expectedGold = 30;
            var targetLocationName = "someRandomString";
            var targetLocationGalaxyName = "JustAnotherRandomString";
            var curentLocationName = "namename";
            var curentGalaxyName = "galaxyname";

            var mockedOwner = Mock.Create<IBusinessOwner>();
            var stationListOfPaths = new List<IPath>();
            var mockedExsistedPath = Mock.Create<IPath>();


            var mockedresurces = Mock.Create<IResources>();
            Mock.Arrange(() => mockedresurces.BronzeCoins).Returns(expectedBronze);
            Mock.Arrange(() => mockedresurces.SilverCoins).Returns(expectedSilver);
            Mock.Arrange(() => mockedresurces.GoldCoins).Returns(expectedGold);

            Mock.Arrange(() => mockedExsistedPath.TargetLocation.Planet.Galaxy.Name).Returns(targetLocationGalaxyName);
            Mock.Arrange(() => mockedExsistedPath.TargetLocation.Planet.Name).Returns(targetLocationName);
            Mock.Arrange(() => mockedExsistedPath.Cost).Returns(mockedresurces);

            stationListOfPaths.Add(mockedExsistedPath);

            var mockedStationLocation = Mock.Create<ILocation>();

            Mock.Arrange(() => mockedStationLocation.Coordinates).Returns(Mock.Create<IGPSCoordinates>());
            var stationPlanet = Mock.Create<IPlanet>();
            Mock.Arrange(() => stationPlanet.Galaxy.Name).Returns(curentGalaxyName);
            Mock.Arrange(() => stationPlanet.Name).Returns(curentLocationName);

            Mock.Arrange(() => mockedStationLocation.Planet).Returns(stationPlanet);

            var mockedUnitToTeleport = Mock.Create<IUnit>();
            Mock.Arrange(() => mockedUnitToTeleport.CurrentLocation).Returns(mockedStationLocation);

            var mockedUnitresurces = Mock.Create<IResources>();
            Mock.Arrange(() => mockedUnitresurces.BronzeCoins).Returns(0);
            Mock.Arrange(() => mockedUnitresurces.SilverCoins).Returns(0);
            Mock.Arrange(() => mockedUnitresurces.GoldCoins).Returns(0);

            var mockedTargetLovation = Mock.Create<ILocation>();
            Mock.Arrange(() => mockedTargetLovation.Planet.Name).Returns(targetLocationName);
            Mock.Arrange(() => mockedTargetLovation.Planet.Galaxy.Name).Returns(targetLocationGalaxyName);

            var station = new TeleportStation(mockedOwner, stationListOfPaths, mockedStationLocation);

            var expected = "FREE LUNCH";
            var result = string.Empty;

            try
            {
                station.TeleportUnit(mockedUnitToTeleport, mockedTargetLovation);

            }
            catch (InsufficientResourcesException ex)
            {
                result = ex.Message;
            }

            StringAssert.Contains(expected, result);

            // added after exam for try
            // Assert.That(() => station.TeleportUnit(mockedUnitToTeleport, mockedTargetLovation), Throws.Exception.Message.Contain(expected));
        }
    }
}

namespace Cars.Tests.JustMock.DataTests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Telerik.JustMock;

    using Cars.Contracts;
    using Cars.Data;

    [TestClass]
    public class CarsRepositoryTest
    {
        [TestMethod]

        public void CarsRepositoryConstructor_ShouldThrowArgumentNullException_IfTakeNullInConstructor()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new CarsRepository(null));
        }

        [TestMethod]
        public void CarsRepositoryData_ShouldReturnTotalCarsProperly()
        {
            var mockCollection = Mock.Create<IList<ICar>>();
            Mock.Arrange(() => mockCollection.Count).OccursOnce();

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(mockCollection);

            var carRepo = new CarsRepository(mockDb);

            var act = carRepo.TotalCars;

            Mock.Assert(mockCollection);
        }

        [TestMethod]
        public void CarsRepositoryAdd_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            var repo = new CarsRepository();

            Assert.ThrowsException<ArgumentNullException>(() => repo.Add(null));
        }

        [TestMethod]
        public void CarRepositoryAdd_ShouldProperlyAddACar()
        {
            var mockCar = Mock.Create<ICar>();

            var mockCollection = Mock.Create<IList<ICar>>();
            Mock.Arrange(() => mockCollection.Add(mockCar)).OccursOnce();

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(mockCollection);

            var repo = new CarsRepository(mockDb);

            repo.Add(mockCar);

            Mock.Assert(mockCollection);
        }

        [TestMethod]
        public void CarsRepositoryRemove_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            var repo = new CarsRepository();

            Assert.ThrowsException<ArgumentNullException>(() => repo.Remove(null));
        }

        [TestMethod]
        public void CarsRepositoryRemove_ShouldRemoveCarProperly()
        {
            var mockCar = Mock.Create<ICar>();

            var mockCollection = Mock.Create<IList<ICar>>();
            Mock.Arrange(() => mockCollection.Remove(mockCar)).OccursOnce();

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(mockCollection);

            var repo = new CarsRepository(mockDb);

            repo.Remove(mockCar);

            Mock.Assert(mockCollection);
        }

        [TestMethod]
        public void CarsRepositoryGetById_ShouldThrowArgumentException_IfCarWithThatIdDoNotExsist()
        {
            var numberOfCars = 5;
            var collection = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var mockCar = Mock.Create<ICar>();
                Mock.Arrange(() => mockCar.Id).Returns(i);

                collection.Add(mockCar);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            Assert.ThrowsException<ArgumentException>(() => repo.GetById(numberOfCars + 5));
        }

        [TestMethod]
        public void CarsRepositoryGetById_ShouldProperlyReturnResult()
        {
            var numberOfCars = 5;
            var rng = new Random();

            var collection = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Id).Returns(i);

                collection.Add(car);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            var expected = rng.Next(numberOfCars);

            Assert.AreEqual(expected, repo.GetById(expected).Id);
        }

        [TestMethod]
        public void CarsRepositoryAll_shouldProperslyReturnResult()
        {
            var Collection = new List<ICar>();

            var car = Mock.Create<ICar>();
            Collection.Add(car);

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(Collection);

            var repo = new CarsRepository(mockDb);

            var expectedList = new List<ICar>(Collection);

            bool areEquals = expectedList.TrueForAll(x => repo.All().Contains(x));

            Assert.IsTrue(areEquals);
        }

        // expected OrderByDecending so our collection is in diferent order! 
        [TestMethod]
        public void CarsRepositorySortBtYear_ShouldReturnSortedCollectionByYear()
        {
            var numberOfCars = 10;
            var rng = new Random();

            var collection = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Year).Returns(1990 + rng.Next(10));
                collection.Add(car);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            var expected = collection
                            .OrderByDescending(x => x.Year)
                            .ToList();

            var result = repo.SortedByYear().ToList();

            bool areEquals = expected.Count == result.Count;

            // if count is diferent no use to check 1 by 1 
            if (areEquals)
            {
                for (int i = 0; i < numberOfCars; i++)
                {
                    if (!expected[i].Equals(result[i]))
                    {
                        areEquals = false;
                    }
                }
            }

            Assert.IsTrue(areEquals);
        }

        [TestMethod]
        public void CarsRepositorySortedByMake_ShouldReturnSortedByMakeCollection()
        {
            var numberOfCars = 10;
            var rng = new Random();

            var collection = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var car = Mock.Create<ICar>();
                var make = new string((char)(65 + rng.Next(26)), rng.Next(10));

                if (i % 2 == 0)
                {
                    make = make.ToUpper();
                }

                Mock.Arrange(() => car.Make).Returns(make);

                collection.Add(car);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            var expected = collection
                            .OrderBy(x => x.Make)
                            .ToList();

            var result = repo
                            .SortedByMake()
                            .ToList();

            var areEquls = expected.Count == result.Count;

            if (areEquls)
            {
                for (int i = 0; i < numberOfCars; i++)
                {
                    if (!expected[i].Equals(result[i]))
                    {
                        areEquls = false;
                    }
                }
            }

            Assert.IsTrue(areEquls);
        }

        [TestMethod]
        public void CarsRepositorySearch_ShouldReturnOriginalCollection_IfConditionIsNull()
        {
            var numberOfCars = 10;

            var collection = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var mockCar = Mock.Create<ICar>();
                collection.Add(mockCar);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            var expected = collection;

            var result = repo.Search(null).ToList();

            var areEquls = expected.Count == result.Count;

            if (areEquls)
            {
                for (int i = 0; i < numberOfCars; i++)
                {
                    if (!expected[i].Equals(result[i]))
                    {
                        areEquls = false;
                    }
                }
            }

            Assert.IsTrue(areEquls);
        }

        [TestMethod]
        public void CarsRepositorySearch_ShouldReturnOriginalCollection_IfConditionIsStringEmpty()
        {
            var numberOfCars = 10;

            var collection = new List<ICar>();

            for (int i = 0; i < numberOfCars; i++)
            {
                var mockCar = Mock.Create<ICar>();
                collection.Add(mockCar);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            var expected = collection;

            var result = repo.Search(string.Empty).ToList();

            var areEquls = expected.Count == result.Count;

            if (areEquls)
            {
                for (int i = 0; i < numberOfCars; i++)
                {
                    if (!expected[i].Equals(result[i]))
                    {
                        areEquls = false;
                    }
                }
            }

            Assert.IsTrue(areEquls);
        }

        [TestMethod]
        public void CarsRepositorySearch_ShouldMatchMakeAndModelInSameTime_AndReturnProperResult()
        {
            // :D 
            int MagicNumberThatScaleCarsCreated = 5;
            var valid = "valid";
            var notValid = "NotValid";
            var collection = new List<ICar>();

            for (int i = 0; i < MagicNumberThatScaleCarsCreated + 1; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Make).Returns(valid);
                Mock.Arrange(() => car.Model).Returns(notValid);
                collection.Add(car);
            }

            for (int i = 0; i < MagicNumberThatScaleCarsCreated - 1; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Make).Returns(notValid);
                Mock.Arrange(() => car.Model).Returns(valid);
                collection.Add(car);
            }

            for (int i = 0; i < MagicNumberThatScaleCarsCreated; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Make).Returns(valid);
                Mock.Arrange(() => car.Model).Returns(valid);
                collection.Add(car);
            }

            for (int i = 0; i < MagicNumberThatScaleCarsCreated; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Make).Returns(notValid);
                Mock.Arrange(() => car.Model).Returns(notValid);
                collection.Add(car);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            Assert.AreEqual(3 * MagicNumberThatScaleCarsCreated, repo.Search(valid).Count);
        }

        [TestMethod]
        public void CarsRepositorySearch_ShouldReturnEmptyCollection_IfNoMatch()
        {
            // :D 
            int MagicNumberThatScaleCarsCreated = 5;
            var valid = "valid";
            var notValid = "NotValid";
            var collection = new List<ICar>();

            for (int i = 0; i < MagicNumberThatScaleCarsCreated; i++)
            {
                var car = Mock.Create<ICar>();
                Mock.Arrange(() => car.Make).Returns(notValid);
                Mock.Arrange(() => car.Model).Returns(notValid);
                collection.Add(car);
            }

            var mockDb = Mock.Create<IDatabase>();
            Mock.Arrange(() => mockDb.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb);

            Assert.AreEqual(0, repo.Search(valid).Count);
        }
    }
}
namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using NUnit.Framework;
    using Moq;

    using Cars.Contracts;
    using Cars.Data;
    using Cars.Models;

    [TestFixture]
    public class CarsRepositoryTest
    {
        [Test]
        public void CarsRepository_ShouldProperlySaveDatabase()
        {
            var mockDb = new Mock<IDatabase>();

            var repo = new CarsRepoChild(mockDb.Object);

            Assert.AreSame(mockDb.Object, repo.GetData());
        }

        [Test]
        public void CarsRepositoryTotalCars_ShouldProperlyReturnCount()
        {
            var expectedCount = 10;

            var collection = new List<Car>();

            for (int i = 0; i < expectedCount; i++)
            {
                collection.Add(new CarChild());
            }

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            Assert.AreEqual(expectedCount, repo.TotalCars);
        }

        //fail coz its throw ArgumentException while I expect ArgumentNullException!
        [Test]
        public void CarsRepositoryAdd_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            var repo = new CarsRepository(new Mock<IDatabase>().Object);

            Assert.Throws<ArgumentNullException>(() => repo.Add(null));
        }

        [Test]
        public void CarsRepositoryAdd_ShouldAddCarProperly()
        {
            var car = new CarChild();

            var collection = new List<Car>();

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepoChild(mockDb.Object);

            repo.Add(car);

            Assert.Contains(car, collection);
        }

        [Test]
        public void CarRepositoryRemove_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            var repo = new CarsRepository(new Mock<IDatabase>().Object);

            Assert.Throws<ArgumentNullException>(() => repo.Remove(null));
        }

        [Test]
        public void CarRepositoryRemove_ShouldRemoveCarProperly()
        {
            var car = new CarChild();

            var collection = new List<Car>();

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            var contains = collection.Contains(car);

            Assert.IsFalse(contains);
        }

        [Test]
        public void CarRepositoryRemove_ShouldNotThrowAnException_IfCarNotFound()
        {
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(new List<Car>());

            var repo = new CarsRepository(mockDb.Object);

            Assert.DoesNotThrow(() => repo.Remove(new CarChild()));
        }

        [Test]
        public void CarsRepositoryGetById_SchhouldThrowAnException_IfIdIsNotFound()
        {
            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(new List<Car>());

            var repo = new CarsRepository(mockDb.Object);

            Assert.Throws<ArgumentException>(() => repo.GetById(8));
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(8)]
        public void CarsRepositoryGetById_ShouldReturnCarProperly(int needed)
        {
            int magicNumberThatIncludeValuesAbove = 10;

            var collection = new List<Car>();

            for (int i = 0; i < magicNumberThatIncludeValuesAbove; i++)
            {
                collection.Add(new CarChild(id: i));
            }

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            Assert.AreEqual(needed, repo.GetById(needed).Id);
        }

        [Test]
        public void CarsRepositoryAll_ShouldReturnListOfCarsProperly()
        {
            int numberOfCars = 7;

            var collection = new List<Car>();

            for (int i = 0; i < numberOfCars; i++)
            {
                collection.Add(new CarChild(id: i));
            }

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            var result = (List<Car>)repo.All();

            CollectionAssert.AreEqual(collection, result);
        }

        [TestCase(4)]
        [TestCase(8)]
        [TestCase(10)]
        [TestCase(13)]
        public void CarsRepositorySortedByMake_ShouldReturnSortedCollection(int numberOfCars)
        {
            var collection = new List<Car>();
            var rng = new Random();

            // make car with random make
            for (int i = 0; i < numberOfCars; i++)
            {
                var makeString = new string(((char)(65 + rng.Next(26))), rng.Next(10));
                makeString = (i % 2) == 0 ? makeString : makeString.ToUpper();

                var car = new CarChild(make: makeString);
                collection.Add(car);
            }

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            var expected = collection
                            .OrderBy(x => x.Make)
                            .ToList();

            CollectionAssert.AreEqual(expected, repo.SortedByMake());
        }

        [TestCase(4)]
        [TestCase(8)]
        [TestCase(10)]
        [TestCase(13)]
        public void CarsRepositorySortByYear_ShouldRetuenSortedCollection(int numberOfCars)
        {
            var collection = new List<Car>();
            var rng = new Random();

            for (int i = 0; i < numberOfCars; i++)
            {
                var car = new CarChild(year: 1980 + rng.Next(10));
                collection.Add(car);
            }

            var mockDb = new Mock<IDatabase>();
            var repo = new CarsRepository(mockDb.Object);

            mockDb.Setup(x => x.Cars).Returns(collection);



            var expected = collection
                            .OrderByDescending(x => x.Year)
                            .ToList();

            CollectionAssert.AreEqual(expected, repo.SortedByYear());
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarsRepositorySearch_ShouldReturnOriginal_IfConditionIsNullOrEmpty(string condition)
        {
            var collection = new List<Car>();

            collection.Add(new CarChild());

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            CollectionAssert.AreEqual(collection, repo.Search(condition));
        }

        [Test]
        public void CarsRepositorySearch_ShouldCheckModelAndMakeInSameTime()
        {
            int magicNumberThatScaleCarCreation = 5;
            string valid = "valid";
            string notvalid = "SOmethingElseTotallyNotValid";

            var collection = new List<Car>();

            // not so crazy :D
            for (int i = 0; i < magicNumberThatScaleCarCreation * 4; i++)
            {
                switch (i % 4)
                {
                    case 0:
                        collection.Add(new CarChild(make: valid, model: notvalid));
                        break;
                    case 1:
                        collection.Add(new CarChild(make: notvalid, model: valid));
                        break;
                    case 2:
                        collection.Add(new CarChild(make: valid, model: valid));
                        break;
                    case 3:
                        collection.Add(new CarChild(make: notvalid, model: notvalid));
                        break;
                }
            }

            var mockDb = new Mock<IDatabase>();
            mockDb.Setup(x => x.Cars).Returns(collection);

            var repo = new CarsRepository(mockDb.Object);

            Assert.AreEqual(magicNumberThatScaleCarCreation * 3, repo.Search(valid).Count);
        }
    }
}

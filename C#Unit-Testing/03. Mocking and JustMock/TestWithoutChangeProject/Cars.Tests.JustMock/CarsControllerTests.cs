namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;
    using Moq;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    [TestFixture]
    public class CarsControllerTests
    {
        [Test]
        public void Index_shouldReturnInstanceOfIView()
        {
            var mockedRepo = new Mock<ICarsRepository>();

            var carController = new CarsController(mockedRepo.Object);

            Assert.IsInstanceOf<IView>(carController.Index());
        }

        [Test]
        public void Index_ShouldReturnAllCars()
        {
            var mockedRepo = new Mock<ICarsRepository>();
            var collection = new List<Car>();
            mockedRepo.Setup(x => x.All()).Returns(collection);

            var carController = new CarsController(mockedRepo.Object);

            Assert.AreEqual(collection, carController.Index().Model);
        }

        [Test]
        public void AddCar_ShouldThrowArgumentNullException_WhenCalledWithNull()
        {
            var controller = new CarsController();

            Assert.Throws<ArgumentNullException>(() => controller.Add(null));
        }

        [TestCase(null)]
        [TestCase("")]
        public void AddCar_ShouldThrowArgumentNullException_WhenCalledWithCarWithModelNullOrEmpty(string model)
        {
            var car = new CarChild(make: "actual make", model: model);

            var controller = new CarsController();

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [TestCase(null)]
        [TestCase("")]
        public void AddCar_ShouldThrowArgumentNullException_WhenCalledWithCarWithMakeNullOrEmpty(string make)
        {
            var car = new CarChild(make: make, model: "valid model");

            var controller = new CarsController();

            Assert.Throws<ArgumentNullException>(() => controller.Add(car));
        }

        [Test]
        public void AddCar_ShouldCallRepositoryAddCar_WithCarPassed()
        {
            var car = new CarChild(id: 5, make: "make", model: "model");

            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.Add(car)).Verifiable();
            mockedRepo.Setup(x => x.GetById(5)).Returns(car);

            var controller = new CarsController(mockedRepo.Object);
            controller.Add(car);

            mockedRepo.Verify(x => x.Add(car), Times.Once);
        }

        [Test]
        public void AddCar_ShouldCallRepositoryGetByIdWithSameIDPassed_IfCarIsValid()
        {
            var expectedId = 8;
            var car = new CarChild(id: expectedId, make: "make", model: "model");

            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.GetById(expectedId)).Returns(car).Verifiable();

            var controller = new CarsController(mockedRepo.Object);
            controller.Add(car);

            mockedRepo.Verify(x => x.GetById(expectedId), Times.Once);
        }

        [Test]
        public void AddCar_ShouldReturnIView_IfCarIsValid()
        {
            var car = new CarChild(5, "make", "model", 2000);

            var mockRepo = new Mock<ICarsRepository>();
            mockRepo.Setup(x => x.GetById(5)).Returns(car);

            var controller = new CarsController(mockRepo.Object);

            Assert.IsInstanceOf<IView>(controller.Add(car));
        }

        [Test]
        public void Details_ShouldThrowArgumentNullException_IfCarIsNull()
        {
            Car car = null;
            var carKid = new CarChild(5, "6", "7", 2000);

            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(car);

            var controller = new CarsController(mockedRepo.Object);

            Assert.Throws<ArgumentNullException>(() => controller.Add(carKid));
        }

        [Test]
        public void Details_ShouldReturnIview_IfCarIdIsValid()
        {
            var expectedId = 444;
            var carKid = new CarChild(expectedId, "6", "7", 2000);

            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(carKid);

            var controller = new CarsController(mockedRepo.Object);

            Assert.IsInstanceOf<IView>(controller.Details(expectedId));
        }

        [TestCase("make")]
        [TestCase("model")]
        public void Search_ShouldCallRepoSearch_WithSameCondition(string condition)
        {
            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.Search(condition)).Verifiable();

            var controller = new CarsController(mockedRepo.Object);
            controller.Search(condition);

            mockedRepo.Verify(x => x.Search(condition), Times.Once);
        }

        [Test]
        public void Search_ShouldreturnIView()
        {
            var mockedRepo = new Mock<ICarsRepository>();

            var controller = new CarsController(mockedRepo.Object);

            Assert.IsInstanceOf<IView>(controller.Search(It.IsAny<string>()));
        }

        [Test]
        public void Sort_ShouldCallSortByYear_WhenCalledWIthYear()
        {
            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.SortedByYear()).Verifiable();

            var controller = new CarsController(mockedRepo.Object);
            controller.Sort("year");

            mockedRepo.Verify(x => x.SortedByYear(), Times.Once);
        }

        [Test]
        public void Sort_ShouldCallSortByMake_WhenCalledWIthMake()
        {
            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.SortedByMake()).Verifiable();

            var controller = new CarsController(mockedRepo.Object);
            controller.Sort("make");

            mockedRepo.Verify(x => x.SortedByMake(), Times.Once);
        }

        [TestCase("randomString")]
        [TestCase("InvalidString")]
        [TestCase("")]
        [TestCase(null)]
        public void Sort_ShouldThrowArgumentException_WhenCalledWithInvalidString(string condition)
        {
            var controller = new CarsController();

            Assert.Throws<ArgumentException>(()=>controller.Sort(condition));
        }

        [TestCase("year")]
        [TestCase("make")]
        public void SortShouldReturnIViewOfICollectionOfCar_WhenCalledWithValidCondition(string condition)
        {
            var collection = new List<Car>();

            var mockedRepo = new Mock<ICarsRepository>();
            mockedRepo.Setup(x => x.SortedByMake()).Returns(collection);
            mockedRepo.Setup(x => x.SortedByYear()).Returns(collection);

            var controller = new CarsController(mockedRepo.Object);

            Assert.IsInstanceOf<IView>(controller.Sort(condition));
        }
    }
}

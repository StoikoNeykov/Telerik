namespace Cars.Tests.JustMock.ControllersTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Telerik.JustMock;

    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;

    [TestClass]
    public class CarsControllerTests
    {
        [TestMethod]
        public void Index_SouldCallRepoAll()
        {
            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.All()).MustBeCalled();

            var controller = new CarsController(mockedRepo);

            controller.Index();

            Mock.Assert(mockedRepo);
        }

        [TestMethod]
        public void Index_ShouldReturnIView()
        {
            var controller = new CarsController(Mock.Create<ICarsRepository>());

            Assert.IsInstanceOfType(controller.Index(), typeof(IView));
        }

        [TestMethod]
        public void Index_ShouldReturnIviewOf_PassedObjectFromRepo()
        {
            var collection = new List<ICar>();

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.All()).Returns(collection);

            var controller = new CarsController(mockedRepo);

            Assert.AreEqual(collection, controller.Index().Model);
        }

        [TestMethod]
        public void Add_ShouldThrowArgumentNullException_WhenCarIsNull()
        {
            var mockedRepo = Mock.Create<ICarsRepository>();

            var controller = new CarsController(mockedRepo);

            Assert.ThrowsException<ArgumentNullException>(() => controller.Add(null));
        }

        [TestMethod]
        public void Add_ShouldThrowArgumentNullException_WhenCarMakeIsNull()
        {
            string nulledString = null;

            var car = Mock.Create<ICar>();
            Mock.Arrange(() => car.Model).Returns("valid");
            Mock.Arrange(() => car.Make).Returns(nulledString);

            var mockedRepo = Mock.Create<ICarsRepository>();

            var controller = new CarsController(mockedRepo);

            Assert.ThrowsException<ArgumentNullException>(() => controller.Add(car));
        }

        [TestMethod]
        public void Add_ShouldThrowArgumentNullException_WhenCarMakeIsEmpty()
        {
            var car = Mock.Create<ICar>();
            Mock.Arrange(() => car.Model).Returns("valid");
            Mock.Arrange(() => car.Make).Returns("");

            var mockedRepo = Mock.Create<ICarsRepository>();

            var controller = new CarsController(mockedRepo);

            Assert.ThrowsException<ArgumentNullException>(() => controller.Add(car));
        }

        [TestMethod]
        public void Add_ShouldThrowArgumentNullException_WhenCarModelIsNull()
        {
            string nulledString = null;

            var car = Mock.Create<ICar>();
            Mock.Arrange(() => car.Make).Returns("valid");
            Mock.Arrange(() => car.Model).Returns(nulledString);

            var mockedRepo = Mock.Create<ICarsRepository>();

            var controller = new CarsController(mockedRepo);

            Assert.ThrowsException<ArgumentNullException>(() => controller.Add(car));
        }

        [TestMethod]
        public void Add_ShouldThrowArgumentNullException_WhenCarModelIsEmpty()
        {
            var car = Mock.Create<ICar>();
            Mock.Arrange(() => car.Make).Returns("valid");
            Mock.Arrange(() => car.Model).Returns("");

            var mockedRepo = Mock.Create<ICarsRepository>();

            var controller = new CarsController(mockedRepo);

            Assert.ThrowsException<ArgumentNullException>(() => controller.Add(car));
        }

        [TestMethod]
        public void Add_ShouldCallRepoCall_WhenCarIsValid()
        {
            var mockedCar = Mock.Create<ICar>();
            Mock.Arrange(() => mockedCar.Make).Returns("make");
            Mock.Arrange(() => mockedCar.Model).Returns("model");

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.Add(mockedCar)).OccursOnce();

            var controller = new CarsController(mockedRepo);

            controller.Add(mockedCar);

            Mock.Assert(mockedRepo);
        }

        [TestMethod]
        public void Add_ShouldReturnIView_WhenCarIsValid()
        {
            var hardcodedId = 5;

            var mockedCar = Mock.Create<ICar>();
            Mock.Arrange(() => mockedCar.Id).Returns(hardcodedId);
            Mock.Arrange(() => mockedCar.Make).Returns("make");
            Mock.Arrange(() => mockedCar.Model).Returns("model");

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.GetById(hardcodedId)).Returns(mockedCar);

            var controller = new CarsController(mockedRepo);

            Assert.IsInstanceOfType(controller.Add(mockedCar), typeof(IView));
        }

        [TestMethod]
        public void Details_ShouldThrowArgumentNullException_WhenRepoReturnNullCar()
        {
            var hardcodedId = 95;
            ICar nullCar = null;

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.GetById(hardcodedId)).Returns(nullCar);

            var controller = new CarsController(mockedRepo);

            Assert.ThrowsException<ArgumentNullException>(() => controller.Details(hardcodedId));
        }

        [TestMethod]
        public void Details_ShouldCallRepoGetById()
        {
            var expectedId = 55;

            var mockRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockRepo.GetById(expectedId))
                                        .Returns(Mock.Create<ICar>())
                                        .OccursOnce();

            var controller = new CarsController(mockRepo);

            controller.Details(expectedId);

            Mock.Assert(mockRepo);
        }

        [TestMethod]
        public void Details_ShouldProperlyReturnInformation()
        {
            var expectedId = 552321312;

            var mockedCar = Mock.Create<ICar>();
            Mock.Arrange(() => mockedCar.Id).Returns(expectedId);

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.GetById(expectedId)).Returns(mockedCar);

            var controller = new CarsController(mockedRepo);

            Assert.AreEqual(mockedCar, controller.Details(expectedId).Model);
        }

        [TestMethod]
        public void Details_ShouldReturnIview()
        {
            var hardcodedId = 77;

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.GetById(hardcodedId)).Returns(Mock.Create<ICar>());

            var controller = new CarsController(mockedRepo);

            Assert.IsInstanceOfType(controller.Details(hardcodedId), typeof(IView));

        }

        [TestMethod]
        public void Search_ShouldCallRepoSearch()
        {
            var expectedCondition = "booo";

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.Search(expectedCondition)).OccursOnce();

            var controller = new CarsController(mockedRepo);
            controller.Search(expectedCondition);

            Mock.Assert(mockedRepo);
        }

        [TestMethod]
        public void Search_ShouldReturnIView()
        {
            var mockedRepo = Mock.Create<ICarsRepository>();

            var controller = new CarsController(mockedRepo);

            Assert.IsInstanceOfType(controller.Search(Arg.AnyString), typeof(IView));
        }

        [TestMethod]
        public void Search_ShouldProperlyReturnInformation()
        {
            var condition = "absolutelyInvalidCondition";

            var collection = new List<ICar>();

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.Search(condition)).Returns(collection);

            var controller = new CarsController(mockedRepo);

            Assert.AreEqual(collection, controller.Search(condition).Model);
        }

        [TestMethod]
        public void Sort_ShouldThrowArgumentException_IfCalledWIthInvalidParameter()
        {
            var totallyInvalidParameter = "Can you imagine parameter like this :D";

            var controller = new CarsController();

            Assert.ThrowsException<ArgumentException>(() => controller.Sort(totallyInvalidParameter));
        }

        [TestMethod]
        public void Sort_ShouldCallRepoSortedByYear_IfCalledWithYear()
        {
            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.SortedByYear()).OccursOnce();

            var controller = new CarsController(mockedRepo);

            controller.Sort("year");

            Mock.Assert(mockedRepo);
        }

        [TestMethod]
        public void Sort_ShouldCallRepoSortedByMake_IfCalledWithMake()
        {
            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.SortedByMake()).OccursOnce();

            var controller = new CarsController(mockedRepo);

            controller.Sort("make");

            Mock.Assert(mockedRepo);
        }

        [TestMethod]
        public void Sort_ShouldReturnIview_WhencalledWithValidParameter()
        {
            var controller = new CarsController(Mock.Create<ICarsRepository>());

            Assert.IsInstanceOfType(controller.Sort("make"), typeof(IView));
        }

        [TestMethod]
        public void Sort_ShpuldProperlyReturnResult_IfCalledWithValidParameter()
        {
            var expectedResult = new List<ICar>();

            var mockedRepo = Mock.Create<ICarsRepository>();
            Mock.Arrange(() => mockedRepo.SortedByMake()).Returns(expectedResult);

            var controller = new CarsController(mockedRepo);

            Assert.AreEqual(expectedResult, controller.Sort("make").Model);
        }
    }
}

using CycleParking;
using CycleParking.Controllers;
using CycleParking.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Unit_test_of_CycleParking
{
    public class CycleParkingTest
    {
        [Fact]
        public void TestforDetails()
        {    // Arrange
            var newobject = new Mock<IDbService>();
            var testSample = new CycleParkingService { Id = 1, Title = "Testtitle",Location="test",Type="test",Secure="test",Availability="test",
                Capacity=0,Longitude="24",Latitude="23" };
            newobject.Setup(x => x.GetCycleParkingDetails(1)).Returns(testSample);

            var controller = new HomeController(newobject.Object);
            // Act
            var result = controller.Details(1) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);
            var model = result.Model as CycleParkingService;
            Assert.NotNull(model);

            Assert.Equal(testSample.Id, model.Id);
            Assert.Equal(testSample.Title, model.Title);
            Assert.Equal(testSample.Location, model.Location);
            Assert.Equal(testSample.Type, model.Type);
            Assert.Equal(testSample.Secure, model.Secure);
            Assert.Equal(testSample.Availability, model.Availability);
            Assert.Equal(testSample.Capacity, model.Capacity);
            Assert.Equal(testSample.Longitude, model.Longitude);
            Assert.Equal(testSample.Latitude, model.Latitude);

        }

        [Fact]
        public void TestforParkingList()
        {
            // Arrange
            var newobject = new Mock<IDbService>();
            var testSample = new List<CycleParkingService> { new CycleParkingService { Id = 1, Type = "Test", Title = "Testtitle" } };
            newobject.Setup(x => x.GetCycleParkings()).Returns(testSample);
            var controller = new HomeController(newobject.Object);
            // Act
            var result = controller.Index("Test") as ViewResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<ViewResult>(result);

            var model = result.Model as List<CycleParkingService>;
            Assert.NotNull(model);
        }

    }

    }

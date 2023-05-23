using api_counter.Controllers;
using NUnit.Framework;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.Repositories;
using System.Xml.Linq;

namespace api_counter.Test
{
    [NonParallelizable]
    [TestFixture]
    public class CoreTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Order(1)]
        [NonParallelizable]
        [Test]
        public void GetCounter()
        {
            // Setup
            CounterController _counterController = new CounterController();
            _counterController.counter = new Counter(0);

            // Arrange
            var expectedData =new Counter(0);

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will return the counter
            var result = _counterController.Get();

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value;
            Assert.IsNotNull(actualData);

            Assert.That(actualData, Is.EqualTo(expectedData.Value));
            
        }

        [Order(2)]
        [NonParallelizable]
        [Test]
        public void IncrementCounter()
        {
            // Setup
            CounterController _counterController = new CounterController();
            _counterController.counter = new Counter (0);

            // Arrange
            var expectedData = new Counter (1);
            var expectedData1 = new Counter (2);

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will increment the counter
            var result = _counterController.Increment();

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value;
            Assert.IsNotNull(actualData);
            Assert.That(actualData, Is.EqualTo(expectedData.Value));

            // Assert
            // @TODO Replace PlaceholderFunction with your own function name that will increment the counter
            result = _counterController.Increment();
            Assert.IsNotNull(result);
            actualData = result.Value;
            Assert.IsNotNull(actualData);
            Assert.That(actualData, Is.EqualTo(expectedData1.Value));
        }

        [Order(4)]
        [NonParallelizable]
        [Test]
        public void DecrementCounter()
        {
            // Setup
            CounterController _counterController = new CounterController();
            _counterController.counter = new Counter (2);

            // Arrange
            var expectedData = new Counter (1);
            var expectedData1 = new Counter (0);

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will decrement the counter
            var result = _counterController.Decrement();

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value;
            Assert.IsNotNull(actualData);
            Assert.That(actualData, Is.EqualTo(expectedData.Value));

            // Assert
            // @TODO Replace PlaceholderFunction with your own function name that will decrement the counter
            result = _counterController.Decrement();
            Assert.IsNotNull(result);
            actualData = result.Value;
            Assert.IsNotNull(actualData);
            Assert.That(actualData, Is.EqualTo(expectedData1.Value));
        }

        [Order(3)]
        [NonParallelizable]
        [Test]
        public void DoubleCounter()
        {
            // Setup
            CounterController _counterController = new CounterController();
           _counterController.counter = new Counter (1, "Counter");

            // Arrange
            var expectedData = new Counter (2);
            var expectedData1 = new Counter (4);

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will double the counter
            var result = _counterController.Double();

            // Assert
            Assert.IsNotNull(result);
            var actualData = result.Value;
            Assert.IsNotNull(actualData);
            Assert.That(actualData, Is.EqualTo(expectedData.Value));

            // Assert
            // @TODO Replace PlaceholderFunction with your own function name that will double the counter
            result = _counterController.Double();
            Assert.IsNotNull(result);
            actualData = result.Value;
            Assert.IsNotNull(actualData);
            Assert.That(actualData, Is.EqualTo(expectedData1.Value));
        }
    }
}
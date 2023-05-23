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
    [TestFixture]
    public class ExtensionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll_ReturnsExpectedData()
        {
            // Arrange
            var expectedData = new List<Counter>
            {
                new Counter(0,"Item 1") ,
                new Counter (0, "Item 2") ,
                new Counter (0, "Item 3")
            };
            CounterController _counterController = new CounterController();
            _counterController.counters.AddRange(expectedData);

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will return all the counters
            var result = _counterController.GetCounters();

            // Assert
            Assert.IsNotNull(result);
            var actualData = result as List<Counter>;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Count, Is.EqualTo(expectedData.Count));
            for (int i = 0; i < expectedData.Count; i++)
            {
                Assert.That(actualData[i].Name, Is.EqualTo(expectedData[i].Name));
                Assert.That(actualData[i].Value, Is.EqualTo(expectedData[i].Value));
            }
        }

        [Test]
        public void CreateCounter_ReturnsExpectedData()
        {
            // Arrange
            CounterController _counterController = new CounterController();
            _counterController.counters.Add(new Counter(0, "Counter"));

            var expectedData = new Counter(0, "Counter 1");

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will create a new named counter
            var result = _counterController.Custom("Counter 1");

            // Assert
            Assert.IsNotNull(result);
            var actualData = result;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
        }

        [Test]
        public void IncrementCustomCounter()
        {
            // Arrange
            CounterController _counterController = new CounterController();
            _counterController.counters.AddRange(new List<Counter>
            {
                new Counter(0,"Counter") ,
                new Counter (0, "Counter 1")
            });

            var expectedData = new Counter (1, "Counter");

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will increment a counter by name
            var result = _counterController.CustomIncrement("Counter");

            // Assert
            Assert.IsNotNull(result);
            var actualData = result;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
        }

        [Test]
        public void DecrementCustomCounter()
        {
            // Arrange
            CounterController _counterController = new CounterController();
            _counterController.counters.AddRange(new List<Counter>
            {
                new Counter (0, "Counter"),
                new Counter (0, "Counter 1")
            });

            var expectedData = new Counter (-1, "Counter");

            // Act
            // @TODO Replace PlaceholderFunction with your own function name that will decrement a counter by name
            var result = _counterController.CustomDecrement("Counter");

            // Assert
            Assert.IsNotNull(result);
            var actualData = result;
            Assert.IsNotNull(actualData);
            Assert.That(actualData.Name, Is.EqualTo(expectedData.Name));
            Assert.That(actualData.Value, Is.EqualTo(expectedData.Value));
        }
    }
}

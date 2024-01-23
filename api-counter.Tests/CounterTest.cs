using api_counter.wwwapi;
using api_counter.wwwapi.Controllers;
using api_counter.wwwapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace api_counter.Tests
{
    [TestFixture]
    public class CounterTest
    {
        WebApplicationFactory<Program> factory;
        HttpClient client;

        [SetUp]
        public void SetUp()
        {
            factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder => { });
            client = factory.CreateClient();
        }

        [Test]
        public async Task GetAllCountersEndpointTest()
        {
            var response = await client.GetAsync("/counter");

            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task When_GetCounters_Then_ResponseShouldBeAllCounters()
        {
            var response = await client.GetAsync("/counter");
            var data = JsonConvert.DeserializeObject<List<Counter>>(await response.Content.ReadAsStringAsync());

            Assert.That(data.Count(), Is.EqualTo(5));
        }

        private async Task<Counter> Deserialize(HttpResponseMessage response)
        {
            return JsonConvert.DeserializeObject<Counter>(await response.Content.ReadAsStringAsync())!;
        }

        [Test]
        public async Task Should_Increment_And_Decrement_CounterValue()
        {
            var response = await client.GetAsync("/counter/3");
            var counter = await Deserialize(response);

            int originalCounterValue = counter.Value;

            response = await client.PutAsync("/counter/increment/3", null);
            counter = await Deserialize(response);

            Assert.That(counter.Value, Is.EqualTo(originalCounterValue + 1));

            response = await client.PutAsync("/counter/decrement/3", null);
            counter = await Deserialize(response);

            Assert.That(counter.Value, Is.EqualTo(originalCounterValue));

        }
    }
}

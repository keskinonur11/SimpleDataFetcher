using System.Net;
using Newtonsoft.Json;
using SDF.Business.ViewModels;
using Shouldly;

namespace SDF.Tests.Integration_Tests
{
    [TestFixture]
    public class QuoteControllerRealTests
    {
        APIFactory factory;
        HttpClient client;

        [OneTimeSetUp]
        public void Init()
        {
            factory = new APIFactory();
            client = factory.CreateClient();
        }

        [Test]
        public async Task GetQuotesTestAsync()
        {
            var result = await client.GetAsync("/get");

            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = await result.Content.ReadAsStringAsync();
            var quotes = JsonConvert.DeserializeObject<List<QuoteViewModel>>(content);

            quotes.ShouldNotBeNull();
            quotes.ShouldAllBe(q => !string.IsNullOrEmpty(q.Text));
        }
    }
}

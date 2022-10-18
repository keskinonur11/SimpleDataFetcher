using SDF.API.Controllers;
using SDF.Business.Implementations;
using SDF.Infrastructure.Interfaces;
using SDF.Tests.TestMocks;
using Shouldly;
using SDF.Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace SDF.Tests.Integration_Tests
{
    [TestFixture]
    public class QuotesControllerMockTests
    {
        [Test]
        public async Task GetQuotesTestAsync()
        {
            var quoteService = new QuoteServiceMock();
            var controller = new QuotesController(quoteService);

            var actionResult = await controller.GetQuotes();
            var quotesResult = actionResult as OkObjectResult;

            quotesResult.ShouldNotBeNull();

            var quotes = (List<QuoteViewModel>)quotesResult.Value!;

            quotes.ShouldAllBe(q => !string.IsNullOrEmpty(q.Author) && !string.IsNullOrEmpty(q.Text));
        }

        [Test]
        public async Task GetQuotesTestAsync_ThrowsException_WhenQuotesEmpty()
        {
            var _quoteRepositoryMock = new Mock<IQuoteRepository>();
            _quoteRepositoryMock.Setup(x => x.GetQuotes(-1))
            .Throws(new Exception("Quote list is empty"));

            var quoteService = new QuoteService(_quoteRepositoryMock.Object);
            var controller = new QuotesController(quoteService);

            var actionResult = await Should.ThrowAsync<Exception>(async () => await controller.GetQuotes());
            actionResult.Message.ShouldBe("Quote list is empty");            
        }
    }
}

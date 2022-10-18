using Moq;
using SDF.Business.Implementations;
using SDF.Business.ViewModels;
using SDF.Infrastructure;
using SDF.Infrastructure.Interfaces;
using SDF.Models.Models;
using SDF.Tests.TestMocks;
using Shouldly;

namespace SDF.Tests;

[TestFixture]
public class QuoteServiceTests
{
    private readonly QuoteService _sut;
    private readonly Mock<IQuoteRepository> _quoteRepositoryMock = new Mock<IQuoteRepository>();

    public QuoteServiceTests()
    {
        _sut = new QuoteService(_quoteRepositoryMock.Object);
    }

    [Test]
    public void RequestQuotes_GetValidQuotes_FromQuoteServiceMock()
    {
        var quoteService = new QuoteServiceMock();
        var quotes = quoteService.GetQuotes();
        
        quotes.ShouldNotBeEmpty();
        quotes.ShouldAllBe(q => !string.IsNullOrEmpty(q.Author) && !string.IsNullOrEmpty(q.Text));
    }

    [Test]
    public void RequtesQuotes_GetValidQuotes_FromMoqRepository()
    {
        var quoteList = new List<Quote>()
        {
            new Quote()
            {
                Text = "Haha",
                Author = "Onur",
                Guid = Guid.NewGuid()
            },
            new Quote()
            {
                Text = "Haha2",
                Author = "Onur2",
                Guid = Guid.NewGuid()
            }
        };

        _quoteRepositoryMock.Setup(x => x.GetQuotes(-1))
            .Returns(quoteList);

        var quotesResult =_sut.GetQuotes();
        quotesResult.ShouldNotBeEmpty();
        quotesResult.ShouldAllBe(q => !string.IsNullOrEmpty(q.Author) && !string.IsNullOrEmpty(q.Text));
    }

    [Test]
    public void RequtesQuotes_ThrowsException_WhenQuotesAreNull_FromMoqRepository()
    {
        _quoteRepositoryMock.Setup(x => x.GetQuotes(-1))
            .Throws(new Exception("Quote list is empty"));

        var ex = Should.Throw<Exception>(() => _sut.GetQuotes()); //.Message.ShouldBe("Quote list is empty");
        ex.Message.ShouldBe("Quote list is empty");
    }
}
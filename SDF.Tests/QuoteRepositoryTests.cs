using SDF.Infrastructure;
using SDF.Infrastructure.Implementations;
using Shouldly;

namespace SDF.Tests
{
    [TestFixture]
    public class QuoteRepositoryTests
    {
        [Test]
        public async Task RequestQuotes_FromSource()
        {
            var quoteRepo = new QuoteRepository();
            var quotes = await quoteRepo.RequestQuotesFromSource();

            quotes.ShouldNotBeNull();
            quotes.ShouldAllBe(q => !string.IsNullOrEmpty(q.Text));
        }

        [Test]
        public async Task FillInMemoryDatabase()
        {
            var quoteRepo = new QuoteRepository();

            InMemoryDatabase.Quotes.ShouldBeEmpty();

            await quoteRepo.FillInMemoryDatabase();

            InMemoryDatabase.Quotes.ShouldNotBeEmpty();
            InMemoryDatabase.Quotes.ShouldAllBe(q => !string.IsNullOrEmpty(q.Text));
        }
    }
}

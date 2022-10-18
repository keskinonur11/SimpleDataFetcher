using SDF.Infrastructure.Interfaces;
using SDF.Models.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace SDF.Infrastructure.Implementations
{
    public class QuoteRepository: IQuoteRepository
    {
        public List<Quote> GetQuotes(int quoteAmount = -1)
        {
            return quoteAmount == -1 ? InMemoryDatabase.Quotes : InMemoryDatabase.Quotes.Take(quoteAmount).ToList();
        }

        public async Task FillInMemoryDatabase()
        {
            var quotes = await RequestQuotesFromSource();

            InMemoryDatabase.Quotes.Clear();
            InMemoryDatabase.Quotes.AddRange(quotes);
        }

        public async Task<List<Quote>> RequestQuotesFromSource(CancellationToken cancellationToken = default)
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync("https://type.fit/api/quotes", cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Failed to get response");
                }

                var content = await response.Content.ReadAsStringAsync(cancellationToken);
                var quotes = JsonConvert.DeserializeObject<List<Quote>>(content);

                if (quotes == null)
                    throw new Exception("Quote list is empty");

                return quotes;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

using SDF.Business.Interfaces;
using SDF.Business.ViewModels;
using SDF.Infrastructure.Interfaces;
using SDF.Infrastructure;

namespace SDF.Business.Implementations
{
    public class QuoteService: IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        public QuoteService(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }   

        public List<QuoteViewModel> GetQuotes(int quoteAmount = -1)
        {
            var quotes = _quoteRepository.GetQuotes(quoteAmount);

            return quotes.Select(quote => new QuoteViewModel() { Author = quote.Author, Text = quote.Text }).ToList();

            //TODO automap
            //return await _quoteRepository.GetQuotes();            
        }

        public void FillInMemoryDatabase()
        {
            _quoteRepository.FillInMemoryDatabase();            
        }
    }
}

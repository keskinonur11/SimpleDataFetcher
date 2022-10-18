using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDF.Models.Models;

namespace SDF.Infrastructure.Interfaces
{
    public interface IQuoteRepository
    {
        public List<Quote> GetQuotes(int quoteAmount = -1);
        public Task FillInMemoryDatabase();
        public Task<List<Quote>> RequestQuotesFromSource(CancellationToken cancellationToken = default);
    }
}

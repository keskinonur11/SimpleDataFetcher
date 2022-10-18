using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDF.Business.ViewModels;

namespace SDF.Business.Interfaces
{
    public interface IQuoteService
    {
        public List<QuoteViewModel> GetQuotes(int quoteAmount = -1);

        public void FillInMemoryDatabase();
    }
}

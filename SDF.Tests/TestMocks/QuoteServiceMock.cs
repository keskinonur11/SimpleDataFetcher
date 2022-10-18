using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDF.Business.Interfaces;
using SDF.Business.ViewModels;
using SDF.Infrastructure;

namespace SDF.Tests.TestMocks
{
    public class QuoteServiceMock: IQuoteService
    {
        public void FillInMemoryDatabase()
        {
            return;
        }

        public List<QuoteViewModel> GetQuotes(int quoteAmount = -1)
        {
            var quoteList = new List<QuoteViewModel>()
            {
                new QuoteViewModel()
                {
                    Author = "Onur",
                    Text = "Text"
                }
            };

            return quoteList;
        }
    }
}

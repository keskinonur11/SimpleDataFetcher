using Microsoft.AspNetCore.Mvc;
using SDF.Business.Interfaces;

namespace SDF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        public QuotesController(IQuoteService qs)
        {
            _quoteService = qs;
        }

        [HttpGet]
        [Route("/get")]
        public async Task<IActionResult> GetQuotes(int quoteAmount = -1)
        {
            return Ok(_quoteService.GetQuotes(quoteAmount));
        }
    }
}

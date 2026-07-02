using Choisium.Application.Abstraction.OtherService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Choisium.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            var quote = await _quoteService.GetRandomQuoteAsync();
            return Ok(quote);
        }
    }
}
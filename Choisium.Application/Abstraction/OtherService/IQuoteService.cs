using Choisium.Application.DTOs.Quote.Response;

namespace Choisium.Application.Abstraction.OtherService
{
    public interface IQuoteService
    {
        Task<QuoteResponse> GetRandomQuoteAsync();
    }
}
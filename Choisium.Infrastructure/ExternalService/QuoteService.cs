using System.Text.Json;
using Choisium.Application.Abstraction.OtherService;
using Choisium.Application.DTOs.Quote.Response;

namespace Choisium.Infrastructure.ExternalService
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _httpClient;

        public QuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<QuoteResponse> GetRandomQuoteAsync()
        {
            var response = await _httpClient.GetAsync("api/random");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            // ZenQuotes devuelve un array, tomamos el primer elemento
            var quotes = JsonSerializer.Deserialize<List<ZenQuoteDto>>(json);
            var quote = quotes?.FirstOrDefault()
                ?? throw new Exception("No se pudo obtener una frase.");

            return new QuoteResponse
            {
                Content = quote.Q,
                Author = quote.A
            };
        }

        // DTO interno que mapea la respuesta cruda de ZenQuotes
        private class ZenQuoteDto
        {
            [System.Text.Json.Serialization.JsonPropertyName("q")]
            public string Q { get; set; } = string.Empty;

            [System.Text.Json.Serialization.JsonPropertyName("a")]
            public string A { get; set; } = string.Empty;
        }
    }
}
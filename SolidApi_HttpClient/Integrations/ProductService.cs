using System;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using Microsoft.Net.Http.Headers;
using src.Controllers.Dtos;

namespace src.Integrations
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            _httpClient.BaseAddress = new Uri("http://localhost:5121");                        
        }

        public async Task CreateProduct(Product product)
        {
            const string branchesUrl = "/products";

            var productItemJson = new StringContent(
                JsonSerializer.Serialize(product),
                Encoding.UTF8,
                MediaTypeNames.Application.Json);
            //productItemJson.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsJsonAsync(branchesUrl, productItemJson);

            result.EnsureSuccessStatusCode();
        }

    }
}


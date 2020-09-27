using Microsoft.Extensions.Logging;
using ServicesStore.Api.ShopingCart.RemoteInterface;
using ServicesStore.Api.ShopingCart.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServicesStore.Api.ShopingCart.RemoteService
{
    public class LibraryBookService : ILibraryBookService
    {
        public readonly IHttpClientFactory _httpclient;
        public readonly ILogger<LibraryBookService> _logger;

        public LibraryBookService(IHttpClientFactory httpclient, ILogger<LibraryBookService> logger) {
            _httpclient = httpclient;
            _logger = logger;
        }

        public async Task<(bool Result, RemoteLibraryBook Book, string errorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var clientName = _httpclient.CreateClient("Books");
                var response  = await clientName.GetAsync($"api/LibraryBook/{BookId}");
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

                    var result = JsonSerializer.Deserialize<RemoteLibraryBook>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}

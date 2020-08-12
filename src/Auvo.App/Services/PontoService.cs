using Auvo.Api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.App.Services
{
    public class PontoService : IPontoService
    {
        private readonly HttpClient _httpClient;

        public PontoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PontoDto>> GetPonto()
        {
            var result = await _httpClient.GetAsync("https://localhost:5001/api/ponto");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PontoDto>>(content);
            }

            return null;
        }

        public async Task<PontoDto> Detalhes(Guid id)
        {
            var result = await _httpClient.GetAsync(string.Format("https://localhost:5001/api/ponto/{0}", id));

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PontoDto>(content);
            }

            return null;
        }

        public async Task<RegistroDto> Create(RegistroDto pontoDto)
        {
            var jsonContent = JsonConvert.SerializeObject(pontoDto);
            var buffer = Encoding.UTF8.GetBytes(jsonContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await _httpClient.PostAsync("https://localhost:5001/api/registro/", byteContent);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<RegistroDto>(content);
            }

            return null;
        }
    }
}

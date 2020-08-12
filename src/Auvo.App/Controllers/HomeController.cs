using Auvo.Api.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Auvo.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient  =  new HttpClient();
      
        private async Task<IEnumerable<PontoDto>> GetPonto()
        {
            var result = await _httpClient.GetAsync("https://localhost:5001/api/ponto");
            
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<PontoDto>>(content);
            }
            return null;
        }

        public async Task<IActionResult> Index()
        {
            var model = await GetPonto();
            return View(model);
        }
    }
}

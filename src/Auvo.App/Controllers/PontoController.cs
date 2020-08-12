using Auvo.Api.Dto;
using Auvo.App.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Auvo.App.Controllers
{
    public class PontoController : Controller
    {
        private readonly IPontoService _pontoService;
        public PontoController(IPontoService pontoService)
        {
            _pontoService = pontoService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _pontoService.GetPonto();
            return View(model);
        }

        public IActionResult CreateRegistro()
        {
            return View();
        }

        public async Task<IActionResult> Detalhes(Guid id)
        {
            var model = await _pontoService.Detalhes(id);
            return View(model);
        }

        public async Task<IActionResult> Create(RegistroDto pontoDto)
        {
            var model = await _pontoService.Create(pontoDto);

            if (model == null)
                return View(model);

            return RedirectToAction("Index");
        }
    }
}
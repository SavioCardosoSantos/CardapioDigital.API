using CardapioDigital.Application.DTOs.Onboarding;
using CardapioDigital.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnboardingController : Controller
    {
        private readonly IOnboardingService _service;

        public OnboardingController(IOnboardingService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CriarOnboardingCliente(OnboardingRequest request)
        {
            await _service.CriarOnboardingCliente(request);
            return Ok("Onboarding registrado com sucesso!");
        }
    }
}

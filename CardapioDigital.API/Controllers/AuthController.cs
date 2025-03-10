using AutoMapper;
using CardapioDigital.Infra.Ioc.Models.Request.Auth;
using CardapioDigital.Infra.Ioc.Models.Response.Auth;
using CardapioDigital.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _service;
        private readonly IMapper _mapper;

        public AuthController(IAuthService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ApiToken>> Autenticar(AuthRequest authRequest)
        {
            var apiToken = new ApiToken(await _service.AuthenticateAsync(authRequest.Email, authRequest.Senha));
            return Ok(apiToken);
        }
    }
}

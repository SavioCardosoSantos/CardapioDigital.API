using CardapioDigital.Application.Interfaces;
using CardapioDigital.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CardapioDigital.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRestauranteRepository _repository;
        private readonly IConfiguration _configuration;

        public AuthService(IRestauranteRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public async Task<string> AuthenticateAsync(string email, string senha)
        {
            var restaurante = await _repository.BuscarPorEmail(email);
            if (restaurante == null)
                throw new UnauthorizedAccessException("Email e/ou senha incorretos.");

            using var hmac = new HMACSHA512(restaurante.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));

            for (int x = 0; x < computedHash.Length; x++)
                if (computedHash[x] != restaurante.PasswordHash[x])
                    throw new UnauthorizedAccessException("Email e/ou senha incorretos.");

            return GenerateToken(restaurante.Id, restaurante.Email);
        }

        private string GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(600);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

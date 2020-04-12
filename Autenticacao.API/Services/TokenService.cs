using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Autenticacao.API.Services
{
    public static class TokenService
    {
        private static readonly string Segredo = "7pQ68BxsdyQQbTNIrG21HQ==";
        private static readonly string Validador = "softplan";

        public static string GerarToken()
        {
            byte[] chave = Convert.FromBase64String(Segredo);
            SymmetricSecurityKey chaveDeSeguranca = new SymmetricSecurityKey(chave);
            SecurityTokenDescriptor descritor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                      new Claim(ClaimTypes.Name, Validador)}),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(chaveDeSeguranca,
                SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descritor);

            return handler.WriteToken(token);
        }

        public static ClaimsPrincipal ObterPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                if (jwtToken == null)
                    return null;

                byte[] chave = Convert.FromBase64String(Segredo);

                TokenValidationParameters parametros = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(chave)
                };

                SecurityToken tokenDeSeguranca;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                      parametros, out tokenDeSeguranca);

                return principal;
            }
            catch
            {
                return null;
            }
        }

        public static bool ValidarToken(string token)
        {
            ClaimsPrincipal principal = ObterPrincipal(token);

            if (principal == null)
                return false;

            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return false;
            }

            Claim claim = identity.FindFirst(ClaimTypes.Name);
            var tokenName = claim.Value;

            return Validador == tokenName;
        }
    }
}

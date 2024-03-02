using Eaconomy.Application.Common.Responses;
using Eaconomy.Application.Repositories;
using Eaconomy.Domain.Entities.Identity;
using Eaconomy.Infrastructure.Data;
using Eaconomy.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Eaconomy.Infrastructure.Repository
{
    public class TokenRepository : ITokenRepository
    {
        private readonly EaconomyDBContext eaconomyDBContext;
        private readonly JwtSettings jwtSettings;

        public TokenRepository(EaconomyDBContext eaconomyDBContext, IOptions<JwtSettings> jwtOptions)
        {
            this.eaconomyDBContext = eaconomyDBContext;
            this.jwtSettings = jwtOptions.Value;
        }

        public async Task<TokenResponse> GetRefreshToken(string token, string refreshToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            var userEmail = securityToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
            TokenResponse tokenResponse = new TokenResponse();

            //var username = principal.Identity.Name;
            var _reftable = eaconomyDBContext.RefreshTokens.FirstOrDefault(o => o.UserEmail == userEmail && o.RefreshToken == refreshToken);
            if (_reftable == null)
            {
                tokenResponse = null;
                return tokenResponse;
            }
            tokenResponse = Authenticate(userEmail, securityToken.Claims.ToArray());
            return tokenResponse;
        }


        public async Task<TokenResponse> GetToken(string userEmail, string password)
        {
            TokenResponse tokenResponse = new TokenResponse();
            //var user = new Users() { Name = "Vikash",
            //    Email =  "Vikash@gmail.com", IsActive=true, Password="password", Role="Admin" };
            //eaconomyDBContext.Users.Add(user);
            //var role = new Roles() { Name="Admin" };
            //eaconomyDBContext.Roles.Add(role);
            //eaconomyDBContext.SaveChanges();
            //var alluSers = eaconomyDBContext.Users.ToList();
            //var roleList = eaconomyDBContext.Roles.ToList();
            //var emp = eaconomyDBContext.Employees.ToList();
            var _user = await eaconomyDBContext.Users.FirstOrDefaultAsync(o => o.Email == userEmail && o.Password == password && o.IsActive == true);
            if (_user == null)
                return tokenResponse;

            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, _user.Name),
                        new Claim(ClaimTypes.Email, _user.Email),
                        new Claim(ClaimTypes.Role, _user.Role)

                    }
                ),
                Expires = DateTime.Now.AddMinutes(jwtSettings.TokenExpirationInMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string finaltoken = tokenhandler.WriteToken(token);

            tokenResponse.JWTToken = finaltoken;
            tokenResponse.RefreshToken = GenerateToken(_user.Email);

            return (tokenResponse);
        }
        private string GenerateToken(string userEmail)
        {
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string RefreshToken = Convert.ToBase64String(randomnumber);

                var _user = eaconomyDBContext.RefreshTokens.FirstOrDefault(o => o.UserEmail == userEmail);
                if (_user != null)
                {
                    _user.RefreshToken = RefreshToken;
                    eaconomyDBContext.SaveChanges();
                }
                else
                {
                    RefreshTokens tblRefreshtoken = new RefreshTokens()
                    {
                        UserEmail = userEmail,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken = RefreshToken,
                        IsActive = true
                    };
                    eaconomyDBContext.RefreshTokens.AddAsync(tblRefreshtoken);
                    eaconomyDBContext.SaveChangesAsync();
                }

                return RefreshToken;
            }
        }

        private TokenResponse Authenticate(string userEmail, Claim[] claims)
        {
            TokenResponse tokenResponse = new TokenResponse();
            var tokenkey = Encoding.UTF8.GetBytes(jwtSettings.Secret);
            var tokenhandler = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256)

                );
            tokenResponse.JWTToken = new JwtSecurityTokenHandler().WriteToken(tokenhandler);
            tokenResponse.RefreshToken = GenerateToken(userEmail);

            return tokenResponse;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PizzaBurgerHouse.DTO;
using PizzaBurgerHouse.Infrastructure.Data;
using PizzaBurgerHouse.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace PizzaBurgerHouse.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {

        private readonly MyApplicationContext db;
        private readonly IOptions<AuthOptions> authOptions;

        public AuthController(MyApplicationContext context, IOptions<AuthOptions> _authOptions)
        {
            db = context;
            authOptions = _authOptions;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
         
            var identity = GetIdentity(loginDto.Email, loginDto.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Неверный пороль или логин" });
            }


            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = db.Accounts.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }




    }




}


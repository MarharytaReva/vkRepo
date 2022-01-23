using BLL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myAPI.Config;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace myAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private UserManager manager;
        public AccountController(UserManager um)
        {
            manager = um;
        }
        [HttpPost]
        public async Task<IActionResult> Token([FromBody] UserDTO user)
        {
            if (user == null)
                return BadRequest(new { error = "Invalid login or password" });
            if (!manager.Login(user.Login, user.Password))
                return BadRequest(new { error = "Invalid login or password" });

            var claim = await GetClaimsIdentity(user.Login);

            string accessToken = GetToken(claim);

            var response = new
            {
                access_token = accessToken,
                username = claim.Name,
                id = manager.GetId(user.Login, user.Password)
            };
            return Json(response);
        }
        [NonAction]
        public string GetToken(ClaimsIdentity claim)
        {
            var now = DateTime.Now;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: claim.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        [NonAction]
        private async Task<ClaimsIdentity> GetClaimsIdentity(string login)
        {
            var claims = new List<Claim>()
                {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
                };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}

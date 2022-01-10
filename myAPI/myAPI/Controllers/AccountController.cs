using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myAPI.Controllers
{
    public class AccountController : Controller
    {
        //private IConfiguration config;
        //private readonly UserManager<IdentityUser> userManager;

        //private readonly SignInManager<IdentityUser> signInManager;
        //public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
        //{
        //    this.userManager = userManager;

        //    config = configuration;
        //    this.signInManager = signInManager;
        //}
        //[HttpPost]
        //public async Task<IActionResult> Token([FromBody] ApiLoginViewModel model)
        //{
        //    var claimsIdentity = await GetClaimsIdentity(model.Login, model.Password);
        //    if (claimsIdentity == null)
        //        return BadRequest(new { errors = "Login or password is not correct" });
        //    var now = DateTime.Now;
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        //    var jwt = new JwtSecurityToken(
        //        issuer: config["Jwt:Issuer"],
        //        audience: config["Jwt:Audience"],
        //        notBefore: now,
        //        claims: claimsIdentity.Claims,
        //        expires: now.AddMinutes(Convert.ToDouble(config["Jwt:LifeTime"])),
        //        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        //        );

        //    string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
        //    var response = new
        //    {
        //        access_token = accessToken,
        //        username = claimsIdentity.Name
        //    };

        //    return Json(response);
        //}
        //private async Task<ClaimsIdentity> GetClaimsIdentity(string login, string password)
        //{
        //    IdentityUser user = await userManager.FindByNameAsync(login);
        //    if (user == null)
        //        return null;
        //    var result = await signInManager.CheckPasswordSignInAsync(user, password, false);
        //    if (result.Succeeded)
        //    {
        //        var roles = await userManager.GetRolesAsync(user);
        //        string role = roles.First();

        //        var claims = new List<Claim>()
        //        {
        //        new Claim(ClaimsIdentity.DefaultNameClaimType, login),
        //        new Claim(ClaimsIdentity.DefaultRoleClaimType, role)
        //        };
        //        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        //        return claimsIdentity;
        //    }
        //    return null;
        //}
    }
}

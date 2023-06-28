using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Panaderia_DonDonas_NET_Core.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Panaderia_DonDonas_NET_Core.Controllers
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountsController: ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountsController(UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.signInManager = signInManager;
        }

        [HttpPost("register")] //api/accounts/register
        public async Task<ActionResult<AutenticationResponse>> Register(UserCredentials usercredentials) 
        {
            var user = new IdentityUser { UserName = usercredentials.Email, 
                Email = usercredentials.Email };
            
            var resultado = await userManager.CreateAsync(user,usercredentials.Password);

            if (resultado.Succeeded)
            {
                return BuildToken(usercredentials);
            }
            else 
            {
                return BadRequest(resultado.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AutenticationResponse>> Login(UserCredentials userCredentials) 
        {
            var resultado = await signInManager.PasswordSignInAsync(userCredentials.Email,
                userCredentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (resultado.Succeeded)
                return BuildToken(userCredentials);
            else
                return BadRequest("Login incorrecto");

        }

        private AutenticationResponse BuildToken(UserCredentials userCredentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email",userCredentials.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["keyjwt"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            var securityToken = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                    expires: expiration, signingCredentials: creds);

            return new AutenticationResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken),
                expiration = expiration
            };
        }
    }
}

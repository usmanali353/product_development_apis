using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly JWTSettings _jwtSetting;
        StringBuilder sb=new StringBuilder();
        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IOptions<JWTSettings> jwtSetting)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            _jwtSetting = jwtSetting.Value;
        }

        [HttpPost,Route("[action]")]
        public async Task<IActionResult> Register(User user) {
            if (ModelState.IsValid) {
                var u = new IdentityUser {UserName=user.Email,Email=user.Email};
                var result=await userManager.CreateAsync(u,user.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(u, isPersistent: true);
                    return Ok(
                        new
                        {
                            message = "Register Sucessful",

                        }

                        );
                }
                else
                    foreach (var error in result.Errors) {
                        sb.Append(error.Description + "\n");
                    }
                return BadRequest(

                    new
                    {
                        message = "Registration Failed",
                        errors = sb.ToString()
                    }
                    ) ;
                
            }
            return BadRequest();
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var u = new IdentityUser { UserName = user.Email, Email = user.Email };
                var result = await signInManager.PasswordSignInAsync(u.Email, user.Password,true,false);
                if (result.Succeeded)
                {
        
                    return Ok(
                        new
                        {
                            message = "Login Sucessful",
                            token= GenerateAccessToken(user.Email)
                        }

                        );
                }
                else
            
                return BadRequest(

                    new
                    {
                        message = "Login Failed",
                        error = "Invalid Login Attempt"
                    }
                    );

            }
            return BadRequest();
        }
        private string GenerateAccessToken(string userId)

        {

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_jwtSetting.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor

            {

                Subject = new ClaimsIdentity(new Claim[]

                {

                    new Claim(ClaimTypes.Email, userId),
                    new Claim(ClaimTypes.Role, "Administrator")

                }),

                Expires = DateTime.UtcNow.AddMinutes(1),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),

                SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }
    }
}

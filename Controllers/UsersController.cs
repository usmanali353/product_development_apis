using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        StringBuilder sb=new StringBuilder();
        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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
    }
}

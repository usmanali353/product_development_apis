using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Model;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        StringBuilder sb = new StringBuilder();
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        public AdministratorController(RoleManager<IdentityRole> roleManager,UserManager<IdentityUser> userManager) {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost, Route("[action]")]
        public async Task<IActionResult> createRole(Roles roles) {
            if (ModelState.IsValid)
            {
                var identityrole = new IdentityRole
                {
                    Name = roles.roleName
                };

                var result = await roleManager.CreateAsync(identityrole);

                if (result.Succeeded)
                {
                    return Ok(
                           new
                           {
                               message = "Role Added Sucessfully",
                           }

                           );
                }
                else
                    foreach (var error in result.Errors)
                    {
                        sb.Append(error.Description + "\n");
                    }
                return BadRequest(

                    new
                    {
                        message = "Role Not Added",
                        errors = sb.ToString()
                    }
                    );
            }
            else
                return BadRequest(
                    new
                    {
                        message = "Role Not Added",
                    }

                    );


        }
        [HttpGet, Route("[action]")]
        public async Task<IEnumerable<IdentityRole>> getRoles()
        {
            var roles = roleManager.Roles;
            return await roles.ToListAsync();
        }
        [HttpGet, Route("[action]")]
        public async Task<IEnumerable<IdentityUser>> getUsers()
        {
            var users = userManager.Users;
            return await users.ToListAsync();
        }
        [HttpPut, Route("[action]")]
        public async Task<IActionResult> editRole([FromQuery] String roleName) 
        {
            var role =await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
                return BadRequest
                    (
                     new {
                         error = "Specified Role does not Exist",
                     }

                    );
            } else
                role.Name = "Administrator";
            var result =await roleManager.UpdateAsync(role);
            if (result.Succeeded) 
            {
                return Ok(
                          new
                          {
                              message = "Role Updated Sucessfully",
                          }

                          );
            }
            else
                return BadRequest
                    (
                     new
                     {
                         error = result.Errors,
                     }

                    );
        }
    }
}

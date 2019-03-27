using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AspDotNetCourseApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspDotNetCourseApp.Helpers
{
    public class IdentitySeed
    {
        private static string[] _roleNames =
        {
            RoleNames.Admin,
            RoleNames.CanManageMovies
        };

        public async Task CreateRolesAsync(ApplicationDbContext context)
        {
            

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityResult roleResult;

            foreach (var roleName in _roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Note: the below didn't work for me - couldn't log in using these details.
            //       I think it has to do with the password hashing. But I don’t have time to dig more into it. 
            //       And it's not that important since this is done one time per project.
            //       Therefore, I will create the roles here but will manually add the users (through the running application)
            //       and connect them to the roles (directly in the DB explorer) and then translate the DB structure to a migration
            //
            // TODO: Get the user name, email and password from the configuraiton files instead of hard coding it:
            //var admin = new ApplicationUser
            //{
            //    UserName = "sarah",
            //    Email = "ashri.sarah@gmail.com",
            //    EmailConfirmed = true

            //};
            //string powerUserPassword = "Aa12345*";
            //var user = await userManager.FindByEmailAsync(admin.Email);
            //if (user == null)
            //{
            //    var createResult = await userManager.CreateAsync(admin, powerUserPassword);
            //    if (createResult.Succeeded)
            //    {                    
            //        var result = await userManager.AddToRoleAsync(admin.Id, RoleNames.ROLE_ADMIN);
            //        Console.Write(result);
            //    }
            //}

        }

    }
}
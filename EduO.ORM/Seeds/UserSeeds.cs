using EduO.Core.Constants;
using EduO.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EduO.ORM.Seeds
{
    public static class UserSeeds
    {
        public static string Permission = "Permission";
        public static string AllModules = "AllModules";
        public static string AdminPassword = "Admin@123";
        public static string AdminUserName = "admin@eduo.com";
        public static string AdminEmail = "admin@eduo.com";
        public static string FirstName = "admin";
        public static string LastName = "admin";


        public static async Task SeedUsers(UserManager<User> userManger, RoleManager<Role> roleManger)
        {
            var defaultAdmin = new User
            {
                UserName = AdminUserName,
                Email = AdminEmail,
                EmailConfirmed = true,
                FirstName = FirstName,
                Middelname = LastName,
                LastName = LastName,
            };

            var user = await userManger.FindByEmailAsync(defaultAdmin.Email);

            if (user == null)
            {
                await userManger.CreateAsync(defaultAdmin, AdminPassword);
                await userManger.AddToRoleAsync(defaultAdmin, Roles.Administrator.ToString());
            }

            await roleManger.SeedClaimsForAdministrator();
        }

        private static async Task SeedClaimsForAdministrator(this RoleManager<Role> roleManger)
        {
            var adminRole = await roleManger.FindByNameAsync(Roles.Administrator.ToString());
            var allClamis = await roleManger.GetClaimsAsync(adminRole);
            var allPermissions = Permissions.GeneratePermissions(AllModules);
            foreach(var permission in allPermissions)
            {
                if (!allClamis.Any(c => c.Type == Permission && c.Value == permission))
                    await roleManger.AddClaimAsync(adminRole,new Claim(Permission, permission));
            }
        }

    }
}

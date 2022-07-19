using EduO.Core.Constants;
using EduO.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.ORM.Seeds
{
    public static class RoleSeeds
    {
        public static async Task SeedRoles(RoleManager<Role> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new Role{ Name = Roles.Administrator.ToString(),NormalizedName = Roles.Administrator.ToString().ToUpper(),active = true});
                await roleManger.CreateAsync(new Role{ Name = Roles.Teacher.ToString(), NormalizedName = Roles.Teacher.ToString().ToUpper(), active = true });
                await roleManger.CreateAsync(new Role{ Name = Roles.Student.ToString(), NormalizedName = Roles.Student.ToString().ToUpper(), active = true });
                await roleManger.CreateAsync(new Role{ Name = Roles.Secretary.ToString(), NormalizedName = Roles.Secretary.ToString().ToUpper(), active = true });
                await roleManger.CreateAsync(new Role{ Name = Roles.Visitor.ToString(), NormalizedName = Roles.Visitor.ToString().ToUpper(), active = true });
            }
        }
    }
}

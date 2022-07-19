using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Models
{
    public class Role : IdentityRole
    {
        public bool active { get; set; }
        public string role_desc { get; set; }
    }
}

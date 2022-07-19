using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Dtos
{
    public class UserDto 
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Middelname { get; set; }
        public string? Password { get; set; }
        public string ImageUrl { get; set; }



    }
}

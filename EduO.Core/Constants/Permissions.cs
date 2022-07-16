using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Constants
{
    public static class Permissions
    {
        public static List<string> GeneratePermissions (string module)
        {
            return new List<string>
            {
                $"{module}.View",
                $"{module}.Create",
                $"{module}.Edit",
                $"{module}.Delete"
            };
        }
    }
}

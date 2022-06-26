using EduO.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduO.Core.Contracts
{
    public interface IGradesRepository : IBaseRepository<Grade>
    {
        //IEnumerable<Grade> SpecialMethod();
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduO.Core.Models
{
    public class Grade : BaseModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace EduO.Core.Models
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}

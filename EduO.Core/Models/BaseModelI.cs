
using System.ComponentModel.DataAnnotations.Schema;

namespace EduO.Core.Models
{
    public class BaseModelI
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

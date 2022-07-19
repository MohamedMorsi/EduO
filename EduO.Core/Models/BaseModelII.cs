
using System.ComponentModel.DataAnnotations.Schema;

namespace EduO.Core.Models
{
    public class BaseModelII
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

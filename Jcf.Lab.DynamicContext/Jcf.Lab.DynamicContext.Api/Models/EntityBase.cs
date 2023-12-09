using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models
{
    public class EntityBase
    {
        public EntityBase()
        {
            IsActivo = true;    
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsActivo { get; set; } = true;
    }
}

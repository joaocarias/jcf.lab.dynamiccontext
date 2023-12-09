using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models
{
    public class Client : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        [Required]
        [StringLength(255)]
        public string ConnectionString { get; private set; }

        public Client(string name, string connectionString) : base()
        {
            Name = name;
            ConnectionString = connectionString;
        }

        private Client() { }
    }
}

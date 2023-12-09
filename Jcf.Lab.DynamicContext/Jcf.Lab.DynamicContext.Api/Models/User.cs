using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        [Required]
        [StringLength(255)]
        public string Email { get; private set; }

        [Required]
        [StringLength(255)]
        public string Password { get; private set; }

        public string Role { get; private set; } = "CLIENT";

        public Guid? ClientId { get; private set; }

        public Client? Client { get; private set; }

        public User(string name, string email, string password, string role, Guid? clientId) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
            ClientId = clientId;
        }

        private User() { }
    
        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetRole(string role)
        {
            Role = role;
        }
    }
}

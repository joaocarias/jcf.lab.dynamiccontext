﻿using System.ComponentModel.DataAnnotations;

namespace Jcf.Lab.DynamicContext.Api.Models
{
    public class Client : EntityBase
    {
        [Required]
        [StringLength(255)]
        public string Name { get; private set; }

        [Required]
        [StringLength(50)]
        public string ClientSetting { get; private set; }

        public Client(string name, string clientSetting):base()
        {
            Name = name;
            ClientSetting = clientSetting;
        }

        private Client() { }
    }
}

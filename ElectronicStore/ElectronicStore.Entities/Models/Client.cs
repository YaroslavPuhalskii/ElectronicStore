using System;
using System.Collections.Generic;

namespace ElectronicStore.Entities.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Birth { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}

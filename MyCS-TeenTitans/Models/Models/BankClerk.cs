using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class BankClerk
    {
        public BankClerk()
        {
            Files = new HashSet<File>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Pass { get; set; }
        public DateTime LastLogin { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}

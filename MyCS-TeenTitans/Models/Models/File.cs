using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class File
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Status { get; set; }
        public DateTime DateAndTime { get; set; }
        public string BankClerkId { get; set; }

        public virtual BankClerk BankClerk { get; set; }
    }
}

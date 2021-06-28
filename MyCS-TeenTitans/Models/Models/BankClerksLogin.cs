using System;
using System.Collections.Generic;

#nullable disable

namespace Data.Models
{
    public partial class BankClerksLogin
    {
        public string Id { get; set; }
        public string BankClerkName { get; set; }
        public DateTime DateAndTime { get; set; }

        public virtual BankClerk IdNavigation { get; set; }
    }
}

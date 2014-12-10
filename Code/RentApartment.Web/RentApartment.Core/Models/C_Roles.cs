using System;
using System.Collections.Generic;

namespace RentApartment.Core.Models
{
    public partial class C_Roles
    {
        public C_Roles()
        {
            this.Accounts = new List<Account>();
        }

        public byte RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}

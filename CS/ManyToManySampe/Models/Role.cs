using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyToManySampe.Models {
    public class Role {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User> UsersInRole{ get; set; }
    }
}
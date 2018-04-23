using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManyToManySampe.Models {
    public class User {

        public int UserID { get; set; }
        public string UserName { get; set; }
        public virtual ICollection<Role> UserRoles { get; set; }
        public User() {
            UserRoles = new List<Role>();
        }
    }
}
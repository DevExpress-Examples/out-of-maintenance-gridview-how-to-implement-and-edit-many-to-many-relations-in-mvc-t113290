using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ManyToManySampe.Models {
    public class ManyToManyInitializer : DropCreateDatabaseIfModelChanges<ManyToManyContext> {

        protected override void Seed(ManyToManyContext context) {
            ManyToManyContext db = new ManyToManyContext();
            base.Seed(context);
            var user1 = new User() { UserID = 1, UserName = "David" };
            var user2 = new User() { UserID = 2, UserName = "Debora" };
            var user3 = new User() { UserID = 3, UserName = "Trevor" };
            var roles = new List<Role>();

            var role1 = new Role { RoleID = 1, RoleName = "Administrator" };
            var role2 = new Role { RoleID = 2, RoleName = "User" };
            var role3 = new Role { RoleID = 3, RoleName = "SuperUser" };
            roles.AddRange(new[] { role1, role2, role3 });
            user2.UserRoles = roles;
            user1.UserRoles = new List<Role> { role1 };
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);
            context.SaveChanges();
        }
    }
}
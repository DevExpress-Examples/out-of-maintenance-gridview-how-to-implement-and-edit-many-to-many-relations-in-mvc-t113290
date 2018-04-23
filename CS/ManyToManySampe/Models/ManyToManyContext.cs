using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManyToManySampe.Models {
    public class ManyToManyContext : DbContext {

        public ManyToManyContext() {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<User>().HasMany(r => r.UserRoles)
                .WithMany(u => u.UsersInRole)
                .Map(mc => {
                    mc.ToTable("T_Users_Roles");
                    mc.MapLeftKey("UserID");
                    mc.MapRightKey("RoleID");
                });
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
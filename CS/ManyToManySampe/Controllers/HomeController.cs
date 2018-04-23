using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using ManyToManySampe.Models;

namespace ManyToManySampe.Controllers {
    public class HomeController : Controller {
        //
        // GET: /Home/
        ManyToManySampe.Models.ManyToManyContext db = new ManyToManySampe.Models.ManyToManyContext();

        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        public ActionResult CallbackAction(int userID, int roleID, bool isLink) {
                if (isLink)
                    db.Users.Find(userID).UserRoles.Add(db.Roles.Find(roleID));
                else
                    db.Users.Find(userID).UserRoles.Remove(db.Roles.Find(roleID));
                db.SaveChanges();
            
            return PartialView("CallbackPartial");
        }
        public ActionResult CallbackAction() {
            return PartialView("CallbackPartial");
        }
        [ValidateInput(false)]
        public ActionResult UsersGridViewPartial() {
            var model = db.Users;
            return PartialView("UsersGridViewPartial", model.ToList());
        }

        [ValidateInput(false)]
        public ActionResult RolesGridViewPartial() {
            var model = db.Roles;
            return PartialView("RolesGridViewPartial", model.ToList());
        }

        public ActionResult UserRolesPartial(int? userID) {
            userID = userID == null ? 1 : userID;
            ViewData["UserRoles"] = db.Users.Find(userID).UserRoles;
            return PartialView();
        }

        public ActionResult UsersInRolePartial(int? roleID) {
            roleID = roleID == null ? 1 : roleID;
            ViewData["UsersInRole"] = db.Roles.Find(roleID).UsersInRole;
            return PartialView();
        }

    }
}

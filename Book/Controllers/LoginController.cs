using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book.Models;

namespace Book.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        dbbookEntities _db = new dbbookEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(tbl_account acc)
        {
            try
            {
                var result = new LoginModel().Login(acc.acc_username, acc.acc_password);

                if (result == 1)
                {

                    Session["admin_id"] = acc.acc_id;
                    return RedirectToAction("Index", "Admin");
                }
                else if (result == 2)
                {
                    int acc_id = _db.tbl_account.Where(x => x.acc_username == acc.acc_username).SingleOrDefault().acc_id;
                    int user_id = _db.tbl_customer.Where(x => x.cus_acc_fk == acc_id).SingleOrDefault().cus_id;

                    Session["user_id"] = user_id;
                    return RedirectToAction("Index", "HomeScreen");
                }
                else if (result == 3)
                {
                    Session["emp_id"] = acc.acc_id;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.msg = "Email or Password Isvalid!";
                }
            }
            catch
            {

            }

            return View();
        }
    }
}
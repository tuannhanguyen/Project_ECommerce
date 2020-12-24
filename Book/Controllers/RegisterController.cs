using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Book.Models;

namespace Book.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterClass a)
        {
            try
            {
                if (a.Confirm != a.Password)
                {
                    ViewBag.msg0 = "";
                }
                else
                {
                    var result = new RegisterModel().Register(a.Name, a.Phone,a.Address, a.Username, a.Password);

                    if (result)
                    {
                        ViewBag.msg1 = "You can back for login!";
                    }
                    else
                    {
                        ViewBag.msg2 = "Username already exists!";
                    }
                }
            }
            catch
            {
            }

            return View();
        }
    }
}
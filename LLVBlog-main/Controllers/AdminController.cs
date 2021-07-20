using LLVBog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LLVBog.Controllers
{
    
    public class AdminController : Controller
    {
        public BlogDataEntities db = new BlogDataEntities();

        // GET: admin
        public ActionResult Statis()
        {

            List<Blog> ListBlog = new List<Blog>();

            ListBlog = db.Blogs.OrderByDescending(s => s.TotalView).ToList();
            return View(ListBlog);
        }

        
        public ActionResult Index()
        {
                string userName = (string)Session["Username"];
                var dataUser = db.Accounts.Where(s => s.Username.Equals(userName) && s.Role.RoleName == "User").ToList();
                if (Session["Username"] == null)
                    return RedirectToAction("Login", "Login");
                else if (Session["Username"] != null)
                {
                    if (dataUser.Count > 0)
                    {
                        TempData["Authorize"] = "User can not access admin page";
                        return RedirectToAction("Index", "Home", ViewBag.Authorize);
                    }
                }
                List<Account> ListAccount = new List<Account>();
                ListAccount = db.Accounts.ToList();
                return View(ListAccount);
        }

        public ActionResult Post()
        {
            List<LLVBog.Models.Action> ListAction = new List<LLVBog.Models.Action>();
            ListAction = db.Actions.ToList();

            return View(ListAction);
        }
    }
}
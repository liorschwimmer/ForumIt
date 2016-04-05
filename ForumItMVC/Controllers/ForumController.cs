using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ForumItMVC.Models;



namespace ForumItMVC.Controllers
{
    public class ForumController : Controller
    {
        // GET: Forum
        public ActionResult Index()
        {
            ForumClient client = new ForumClient();

            ViewBag.aaa = client.GetAllForums(); 


            return View();
        }
    }
}
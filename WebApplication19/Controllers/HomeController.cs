using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class HomeController : Controller
    {
          
        project124Entities p1 = new project124Entities();

        
        public ActionResult Index()
        {

            return View(p1.disps.ToList());
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(disp dd)
        {
            p1.disps.Add(dd);
            p1.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Search(string SearchBy, string search_data)
        {
            List<disp> data_search = new List<disp>();

            if (SearchBy == "name")
            {
                data_search = p1.disps.Where(model => model.UName == search_data).ToList();
            }
            else if (SearchBy == "Email")
            {
                data_search = p1.disps.Where(model => model.Usergmail == search_data).ToList();
            }
            

            return View(data_search);
        }

    }
}
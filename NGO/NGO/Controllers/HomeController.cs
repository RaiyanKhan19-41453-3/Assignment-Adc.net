using NGO.EF;
using NGO.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace NGO.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Logout() {
            Session["UserId"] = null;
            Session["OwnerId"] = null;
            Session["RestaurantId"] = null;
            return RedirectToAction("Index"); }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }








        //Employee jinish
        [HttpGet]
        public ActionResult EmployeeRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeRegistration(Employee emp)
        {
            if(ModelState.IsValid)
            {
                NGOContext context = new NGOContext();
                context.Employees.Add(emp);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(Employee emp)
        {
            NGOContext ctx = new NGOContext();
            var user = (from e in ctx.Employees
                        where e.EmpName.Equals(emp.EmpName) &&
                        e.Password.Equals(emp.Password)
                        select e).FirstOrDefault();
            if (user != null)
            {
                Session["UserId"] = user.EmpId;
                return RedirectToAction("EmployeeHomepage");
            }
            ViewBag.Msg = "Invalid";
            return View(emp);
        }

        [HttpGet]
        public ActionResult EmployeeHomepage()
        {
            NGOContext context = new NGOContext();
            var id = (int)Session["UserId"];
            var Collections = context.DonationCollections.Where(dc=>dc.EmployeeId == id).ToList();
            return View(Collections);
        }
        [HttpGet]
        public ActionResult Done(int id)
        {
            NGOContext context = new NGOContext();
            var ChangeStatus = context.DonationCollections.Find(id);
            ChangeStatus.Status = "Done" + DateTime.Now.Date.ToString();
            ChangeStatus.DonationRequest.Status = ChangeStatus.Status;
            context.SaveChanges();
            return RedirectToAction("EmployeeHomepage");
        }








        // Owner jinish
        [HttpGet]
        public ActionResult OwnerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OwnerLogin(Owner ow)
        {
            NGOContext ctx = new NGOContext();
            var user = (from o in ctx.Owners
                        where o.OwnerId.Equals(ow.OwnerId) &&
                        o.OwnerName.Equals(ow.OwnerName)
                        select o).FirstOrDefault();
            if (user != null)
            {
                Session["OwnerId"] = user.OwnerId;
                return RedirectToAction("OwnerHomepage");
            }
            ViewBag.Msg = "Invalid";
            return View(ow);
        }
        [HttpGet]
        public ActionResult OwnerHomePage()
        {
            NGOContext ctx = new NGOContext();
            var Requests = ctx.DonationRequests.ToList();

            return View(Requests);
        }
        [HttpGet]
        public ActionResult OwnerSelectEmployee(int id)
        {
            NGOContext ctx = new NGOContext();
            
            var DCs = ctx.DonationCollections.Where(dc=>dc.DonationId == id).ToList();
            var Employees = ctx.Employees.ToList();
            var FreeWorkers = Employees;

            foreach(var item in FreeWorkers.ToList())
            {
                foreach(var item2 in DCs)
                {
                    if(item.EmpId == item2.EmployeeId)
                    {
                        FreeWorkers.Remove(item);
                        break;
                    }
                }
            }

            /*var FreeWorker = from emp in ctx.Employees
            where ctx.DonationCollections.Any(
                dc => dc.DonationId == id && 
                dc.EmployeeId != emp.EmpId)
                select emp;

            var FreeWorkers = FreeWorker.ToList();*/
            TempData["DonateId"] = id;
            TempData["Count"] = FreeWorkers.Count;
            return View(FreeWorkers);
        }
        [HttpPost]
        public ActionResult OwnerSelectEmployee(int[] Workers)
        {
            NGOContext context = new NGOContext();
            var i = (int)TempData["DonateId"];
            foreach (var item in Workers)
            {
                context.DonationCollections.Add(new DonationCollection()
                {
                    DonationId = i, EmployeeId = item, Status = "Assigned"
                });
            }
            var Donation = context.DonationRequests.Find(i);
            Donation.Status = "Assigned";
            context.SaveChanges();
            

            return RedirectToAction("OwnerHomePage");
        }







        //Restaurant jinish
        [HttpGet]
        public ActionResult RestaurantLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestaurantLogin(Restaurant re)
        {
            NGOContext ctx = new NGOContext();
            var user = (from r in ctx.Restaurants
                        where r.RestaurantName.Equals(re.RestaurantName) &&
                        r.Password.Equals(re.Password)
                        select r).FirstOrDefault();
            if (user != null)
            {
                Session["RestaurantId"] = user.RestaurantId;
                return RedirectToAction("RestaurantHomePage");
            }
            ViewBag.Msg = "Invalid";
            return View(re);
        }
        [HttpGet]
        public ActionResult RestaurantHomePage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestaurantHomePage(DonationRequest dr)
        {
            NGOContext context = new NGOContext();
            context.DonationRequests.Add(new DonationRequest()
            {
                RestaurantId = (int)Session["RestaurantId"], 
                ExpirationDate = dr.ExpirationDate, 
                Weight = dr.Weight, 
                Status="Un-Assigned"
            });
            context.SaveChanges();
            ViewBag.msg = "Successful";
            return View(dr);
        }
    }
}
using Cash_Flow.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data;
using System;

namespace Cash_Flow.Controllers
{
    public class CashFlowController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        CashFlowEntities db = new CashFlowEntities();

        public CashFlowController()
        {
        }

        public CashFlowController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Diagram()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            var result = db.DataTable.Where(dt => dt.User.Email == user.Email).ToList();

            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();
            ArrayList zValue = new ArrayList();

            foreach (var item in result)
            {
                xValue.Add(item.Date);
                if (item.TransactionTypeId == 1) {
                    yValue.Add(item.Value);
                    zValue.Add(0);
                }
                else
                {
                    zValue.Add(item.Value);
                    yValue.Add(0);
                }
            }

            new Chart(width: 900, height: 500, theme: ChartTheme.Blue)
                .AddTitle("Cash-Flow Summary")
                .AddSeries("Income", chartType: "Column", chartArea: "",legend:"" ,markerStep:20, xValue: xValue, yValues: yValue)
                .AddSeries("Expense", chartType: "Column", chartArea: "", xValue: xValue, yValues: zValue)
                .AddLegend(title:"Inputs",name: "something")
                
                .Write();

            return View();
        }

        // GET: CashFlow     

        public ActionResult CashFlow()
        {
            try
            {

   
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            var result2 = db.DataTable.Where(dt => dt.User.Email == user.Email);

            var getResult = db.DataTable.Where(dt => dt.TransactionTypeId == 1 && dt.User.Email == user.Email).ToList();
            var getNegResult = db.DataTable.Where(dt => dt.TransactionTypeId == 2 && dt.User.Email == user.Email).ToList();

            ArrayList x2Value = new ArrayList();
            ArrayList y2Value = new ArrayList();
            ArrayList z2Value = new ArrayList();

            foreach (var item in result2)
            {
                x2Value.Add(item.Date);

                if (item.TransactionTypeId == 1)
                {
                    y2Value.Add(item.Value);
                    z2Value.Add(0);
                }
                else
                {
                    z2Value.Add(item.Value*-1);
                    y2Value.Add(0);
                }
            }
            new Chart(width: 900, height: 500, theme: ChartTheme.Green)
            .AddTitle("Cash-Flow Summary2")
            .AddSeries("Income", chartType: "Column", chartArea: "", legend: "", markerStep: 20, xValue: x2Value, yValues: y2Value)
            .AddSeries("Expense", chartType: "Column", chartArea: "", xValue: x2Value, yValues: z2Value)
            .AddLegend(title: "Inputs", name: "something")

            .Write();
            
            }
            catch (Exception ex)
            {
                throw;
            }

            return View();
         
        }
        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

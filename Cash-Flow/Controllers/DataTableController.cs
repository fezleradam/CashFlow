using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Cash_Flow.Models;
using Microsoft.AspNet.Identity;


namespace Cash_Flow.Controllers
{
    public class DataTableController : Controller
    {
        CashFlowEntities db = new CashFlowEntities();

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
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


        // GET: DataTable
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);

            var model = db.DataTable.Where(dt => dt.User.Email == user.Email).Select(x => new DataTableViewModel()
            {
                Date = x.Date,
                Description = x.Description,
                TransactionTypeId = x.TransactionTypeId,
                Value = x.Value,
                Id = x.Id,
                TransactionTypeName = x.TransactionType1.Name,
            }).ToList();

            return View(model);
        }

        // GET: AddData

        public ActionResult DataTable()
        {
            ViewBag.TransactionTypeList = db.TransactionType.ToList();
            return View();
        }
        
        // Post: AddData

        [HttpPost]
        public ActionResult DataTable(DataTableViewModel model)
        {
            var userId = User.Identity.GetUserId();
            var user = UserManager.FindById(userId);
            var dbUser = db.User.FirstOrDefault(u => u.Email == user.Email);            

            if (ModelState.IsValid)
            {
                db.DataTable.Add(new DataTable()
                {
                    UserId = dbUser.Id,
                    Description = model.Description,
                    Date = model.Date,
                    Value = model.Value,
                    TransactionTypeId = model.TransactionTypeId             
                });
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(model);
        }


        // GET: Authors/Delete/5

        [ActionName("Delete")]
        public ActionResult DeleteGet(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataTable dataTable = db.DataTable.Find(Id);
            if (dataTable == null)
            {
                return HttpNotFound();
            }
            return View(dataTable);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            DataTable dataTable = db.DataTable.Find(Id);
            db.DataTable.Remove(dataTable);

            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Authors/Edit/5

        [ActionName("Edit")]
        public ActionResult EditGet(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DataTable dataTable = db.DataTable.Find(Id);
            if (dataTable == null)
            {
                return HttpNotFound();
            }
            return View(dataTable);
        }

        [HttpPost, ActionName("Edit")]
        public ActionResult EditPost(DataTableViewModel model)
        {

            if (ModelState.IsValid)
            {

                var entryToUpdate = db.DataTable.Where(p => p.Id == model.Id).FirstOrDefault();

                entryToUpdate.UserId = 1;
                entryToUpdate.Description = model.Description;
                entryToUpdate.Date = model.Date;
                entryToUpdate.Value = model.Value;
                entryToUpdate.TransactionTypeId = model.TransactionTypeId;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
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
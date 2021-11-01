using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MyTimeHub.Context;
using MyTimeHub.Models;
using Newtonsoft.Json;

namespace MyTimeHub.Controllers
{
    public class BookingsController : Controller
    {
        private MyTimeHubDBContext db = new MyTimeHubDBContext();

        [HttpGet]
        public string GetBookingsForUser(int userId)
        {
            var bookings = db.Bookings.Where(b => b.EmployeeID == userId).Include(b => b.Customer).Include(b => b.Employee).Include(b => b.ServiceType);
            return JsonConvert.SerializeObject(bookings);
        }

        [HttpGet]
        public FileResult GetExportForCustomer(int customerId)
        {
            var bookings = db.Bookings.Where(b => b.CustomerID == customerId).Include(b => b.Customer).Include(b => b.Employee).Include(b => b.ServiceType);
            var bList = bookings.ToList();

            string csv = ListToCSV(bList);

            return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv", "report.csv");
        }
        private string ListToCSV<T>(IEnumerable<T> list)
        {
            StringBuilder sList = new StringBuilder();

            Type type = typeof(T);
            var props = type.GetProperties();
            sList.Append(string.Join(",", props.Select(p => p.Name)));
            sList.Append(Environment.NewLine);

            foreach (var element in list)
            {
                sList.Append(string.Join(",", props.Select(p => p.GetValue(element, null))));
                sList.Append(Environment.NewLine);
            }

            return sList.ToString();
        }

        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Customer).Include(b => b.Employee).Include(b => b.ServiceType);
            return View(bookings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        public ActionResult Create(DateTime? start, DateTime? end, string employee = "")
        {

            var booking = new Booking();
            if (start != null && end != null && employee != null)
            {
                booking.EmployeeID = int.Parse(employee);
                booking.Date = Convert.ToDateTime(start);
                booking.StartDate = Convert.ToDateTime(start);
                booking.EndDate = Convert.ToDateTime(end);
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name");
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name");
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Date,StartDate,EndDate,Description,IsActive,EmployeeID,CustomerID,ServiceTypeID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.IsActive = true;
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", booking.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", booking.EmployeeID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name", booking.ServiceTypeID);

            return View(booking);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", booking.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", booking.EmployeeID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name", booking.ServiceTypeID);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Date,StartDate,EndDate,Description,IsActive,EmployeeID,CustomerID,ServiceTypeID")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "ID", "Name", booking.CustomerID);
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "Name", booking.EmployeeID);
            ViewBag.ServiceTypeID = new SelectList(db.ServiceTypes, "ID", "Name", booking.ServiceTypeID);
            return View(booking);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
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

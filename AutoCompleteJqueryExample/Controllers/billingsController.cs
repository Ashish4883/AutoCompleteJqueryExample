using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoCompleteJqueryExample.Models;

namespace AutoCompleteJqueryExample.Controllers
{
    public class billingsController : Controller
    {
        private CityContext db = new CityContext();

        // GET: billings
        public ActionResult Index()
        {
            return View(db.billings.ToList());
        }

        // GET: billings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billing billing = db.billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        public ActionResult Report()
        {
            string command = "select sum(billAmount) as bm from billing where region in ('north','south')";
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["CityContext"].ToString());
            SqlCommand cmd = new SqlCommand(command,con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            float val = float.Parse(dt.Rows[0]["bm"].ToString());
            ViewBag.amount = val;

            return View();
        }

        // GET: billings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: billings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ClientID,region,billAmount")] billing billing)
        {
            if (ModelState.IsValid)
            {
                db.billings.Add(billing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billing);
        }

        // GET: billings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billing billing = db.billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: billings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ClientID,region,billAmount")] billing billing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billing);
        }

        // GET: billings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            billing billing = db.billings.Find(id);
            if (billing == null)
            {
                return HttpNotFound();
            }
            return View(billing);
        }

        // POST: billings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            billing billing = db.billings.Find(id);
            db.billings.Remove(billing);
            db.SaveChanges();
            return RedirectToAction("Index");
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

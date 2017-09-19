using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M2M;

namespace M2M.Controllers
{
    public class JobTagController : Controller
    {
        private JobPortalContainer db = new JobPortalContainer();

        // GET: JobTag
        public ActionResult Index()
        {
            return View(db.JobTags.ToList());
        }

        // GET: JobTag/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTag jobTag = db.JobTags.Find(id);
            if (jobTag == null)
            {
                return HttpNotFound();
            }
            return View(jobTag);
        }

        // GET: JobTag/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobTag/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tag")] JobTag jobTag)
        {
            if (ModelState.IsValid)
            {
                db.JobTags.Add(jobTag);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobTag);
        }

        // GET: JobTag/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTag jobTag = db.JobTags.Find(id);
            if (jobTag == null)
            {
                return HttpNotFound();
            }
            return View(jobTag);
        }

        // POST: JobTag/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tag")] JobTag jobTag)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobTag).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobTag);
        }

        // GET: JobTag/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobTag jobTag = db.JobTags.Find(id);
            if (jobTag == null)
            {
                return HttpNotFound();
            }
            return View(jobTag);
        }

        // POST: JobTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobTag jobTag = db.JobTags.Find(id);
            db.JobTags.Remove(jobTag);
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

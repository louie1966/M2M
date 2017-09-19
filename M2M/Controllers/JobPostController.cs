using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using M2M;
using M2M.ViewModel;

namespace M2M.Controllers
{
    public class JobPostController : Controller
    {
        private JobPortalContainer db = new JobPortalContainer();

        // GET: JobPost
        public ActionResult Index()
        {
            var jobPosts = db.JobPosts.Include(j => j.Employer);
            return View(jobPosts.ToList());
        }

        // GET: JobPost/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // GET: JobPost/Create
        public ActionResult Create()
        {
            ViewBag.EmployerId = new SelectList(db.Employers, "Id", "FullName");
            return View();
        }

        // POST: JobPost/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,EmployerId")] JobPost jobPost)
        {
            if (ModelState.IsValid)
            {
                db.JobPosts.Add(jobPost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployerId = new SelectList(db.Employers, "Id", "FullName", jobPost.EmployerId);
            return View(jobPost);
        }

        // GET: JobPost/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var jobPostViewModel = new JobPostViewModel {
                JobPost = db.JobPosts.Include(i => i.JobTags).First(i => i.Id == id),
            };

            if (jobPostViewModel.JobPost == null)
                return HttpNotFound();

            var allJobTagsList = db.JobTags.ToList();
            jobPostViewModel.AllJobTags = allJobTagsList.Select(o => new SelectListItem {
                Text = o.Tag,
                Value = o.Id.ToString()
            });

            ViewBag.EmployerID =
                    new SelectList(db.Employers, "Id", "FullName", jobPostViewModel.JobPost.EmployerId);

            return View(jobPostViewModel);
        }

      
        // Not bind if the name is jobpost
        // POST: /JobPost/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//[Bind(Include = "Title,Id,EmployerID,SelectedJobTags")]
        public ActionResult Edit(JobPostViewModel jobpostView) {

            if (jobpostView == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);



            if (ModelState.IsValid) {
                var jobToUpdate = db.JobPosts
                    .Include(i => i.JobTags).First(i => i.Id == jobpostView.JobPost.Id);

                if (TryUpdateModel(jobToUpdate, "JobPost", new string[] { "Title", "EmployerID" })) {
                    var newJobTags = db.JobTags.Where(
                        m => jobpostView.SelectedJobTags.Contains(m.Id)).ToList();
                    var updatedJobTags = new HashSet<int>(jobpostView.SelectedJobTags);
                    foreach (JobTag jobTag in db.JobTags) {
                        if (!updatedJobTags.Contains(jobTag.Id)) {
                            jobToUpdate.JobTags.Remove(jobTag);
                        }
                        else {
                            jobToUpdate.JobTags.Add((jobTag));
                        }
                    }

                    db.Entry(jobToUpdate).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "Id", "FullName", jobpostView.JobPost.EmployerId);
            return View(jobpostView);
        }

        // GET: JobPost/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPost jobPost = db.JobPosts.Find(id);
            if (jobPost == null)
            {
                return HttpNotFound();
            }
            return View(jobPost);
        }

        // POST: JobPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPost jobPost = db.JobPosts.Find(id);
            db.JobPosts.Remove(jobPost);
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

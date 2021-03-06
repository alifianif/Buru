﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Buru.Models;
using System.Data.Entity.Infrastructure;

namespace Buru.Controllers
{
    public class BugController : Controller
    {
        private BuruDataEntities5 db = new BuruDataEntities5();

        // GET: Bug
        public ActionResult Index()
        {
            /*var viewModel = new Project();
            if (ProjectId != null)
            {
                ViewBag.ProjectId = ProjectId.Value;
                viewModel.ListBugs = viewModel.ListBugs.Where(
                  x => x.ProjectId == ProjectId).ToList<Bug>;
                //var selectedCourse = viewModel.Courses.Where(x => x.CourseID == courseID).Single();
                //db.Entry(selectedCourse).Collection(x => x.Enrollments).Load();
                //foreach (Enrollment enrollment in selectedCourse.Enrollments)
                //{
                    //db.Entry(enrollment).Reference(x => x.Student).Load();
                //}
                //viewModel.Enrollments = selectedCourse.Enrollments;
            }

            return View(viewModel);*/
                return View(db.Bugs.ToList());
        }

        // GET: Bug/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // GET: Bug/Create
        public ActionResult Create()
        {
            List<string> BugKind = new List<string>();
            List<string> BugSeverity = new List<string>();

            BugKind.Add("Bug");
            BugKind.Add("Feedback");

            BugSeverity.Add("Critical");
            BugSeverity.Add("High");
            BugSeverity.Add("Medium");
            BugSeverity.Add("Low");

            ViewBag.BugKind = BugKind;
            ViewBag.BugSeverity = BugSeverity;

            return View();
        }

        // POST: Bug/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BugId,Title,Description,Steps,Attachment,Assignee,CreatedDate,ClosedDate,Severity,Kind,Status")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                db.Bugs.Add(bug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bug);
        }

        // GET: Bug/Edit/5
        public ActionResult Edit(int? id)
        {
            List<string> BugKind = new List<string>();
            List<string> BugSeverity = new List<string>();

            BugKind.Add("Bug");
            BugKind.Add("Feedback");

            BugSeverity.Add("Critical");
            BugSeverity.Add("High");
            BugSeverity.Add("Medium");
            BugSeverity.Add("Low");

            ViewBag.BugKind = BugKind;
            ViewBag.BugSeverity = BugSeverity;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // POST: Bug/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BugId,Title,Description,Steps,Attachment,Assignee,CreatedDate,ClosedDate,Severity,Kind,Status")] Bug bug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bug);
        }

        // GET: Bug/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // POST: Bug/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug bug = db.Bugs.Find(id);
            db.Bugs.Remove(bug);
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

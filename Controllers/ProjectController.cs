using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Buru.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Buru.JsonFormatted;
using Newtonsoft.Json;

namespace Buru.Controllers
{
    public class ProjectController : Controller
    {
        private BuruDataEntities5 db = new BuruDataEntities5();
        private static readonly HttpClient client = new HttpClient();

        // GET: Project
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var id = System.IO.File.ReadAllText(@"D:\Visual Studio\idcompany.txt");
            var access_token = System.IO.File.ReadAllText(@"D:\Visual Studio\params1.txt");
            string projects = string.Format("https://3.basecampapi.com/" + id + "/projects.json");
            var stringbuilder = new StringBuilder(projects);
            //System.IO.File.WriteAllText(@"D:\Visual Studio\link.txt", projects);
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + access_token);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Buru Bugs (alifiani12@gmail.com)");
            using (HttpResponseMessage responseMessage = await client.GetAsync(projects))
            {
                using (HttpContent content = responseMessage.Content)
                {
                    string mycontent = await content.ReadAsStringAsync();
                    //System.IO.File.WriteAllText(@"D:\Visual Studio\projects5.txt", mycontent);
                }
            }
                return View(db.Projects.ToList());
        }

        //add to db
        public void addToDb (string content)
        {
            List<ProjectBC> proj = JsonConvert.DeserializeObject<List<ProjectBC>>(content);
            foreach (var project in proj)
            {

            }
        }

        // GET: Project/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.AkunId = new SelectList(db.Akuns, "AkunId", "Usrnm");
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,Name,DueDate,AkunId")] Models.Project project)
        {
            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }

            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,Name,DueDate,AkunId")] Models.Project project)
        {
            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Project project = db.Projects.Find(id);
            db.Projects.Remove(project);
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

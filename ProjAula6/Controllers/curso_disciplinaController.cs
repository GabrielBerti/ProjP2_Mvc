using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjAula6;

namespace ProjAula6.Controllers
{
    public class curso_disciplinaController : Controller
    {
        private projP2Entities db = new projP2Entities();

        // GET: curso_disciplina
        public ActionResult Index()
        {
            var curso_disciplina = db.curso_disciplina.Include(c => c.curso).Include(c => c.disciplina);
            return View(curso_disciplina.ToList());
        }

        // GET: curso_disciplina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            curso_disciplina curso_disciplina = db.curso_disciplina.Find(id);
            if (curso_disciplina == null)
            {
                return HttpNotFound();
            }
            return View(curso_disciplina);
        }

        // GET: curso_disciplina/Create
        public ActionResult Create()
        {
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome");
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome");
            return View();
        }

        // POST: curso_disciplina/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_curso,id_disciplina,id")] curso_disciplina curso_disciplina)
        {
            if (ModelState.IsValid)
            {
                db.curso_disciplina.Add(curso_disciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_curso = new SelectList(db.curso, "id", "nome", curso_disciplina.id_curso);
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome", curso_disciplina.id_disciplina);
            return View(curso_disciplina);
        }

        // GET: curso_disciplina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            curso_disciplina curso_disciplina = db.curso_disciplina.Find(id);
            if (curso_disciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome", curso_disciplina.id_curso);
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome", curso_disciplina.id_disciplina);
            return View(curso_disciplina);
        }

        // POST: curso_disciplina/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_curso,id_disciplina,id")] curso_disciplina curso_disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(curso_disciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome", curso_disciplina.id_curso);
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome", curso_disciplina.id_disciplina);
            return View(curso_disciplina);
        }

        // GET: curso_disciplina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            curso_disciplina curso_disciplina = db.curso_disciplina.Find(id);
            if (curso_disciplina == null)
            {
                return HttpNotFound();
            }
            return View(curso_disciplina);
        }

        // POST: curso_disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            curso_disciplina curso_disciplina = db.curso_disciplina.Find(id);
            db.curso_disciplina.Remove(curso_disciplina);
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

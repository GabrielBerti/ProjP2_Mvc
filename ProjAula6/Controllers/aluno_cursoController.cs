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
    public class aluno_cursoController : Controller
    {
        private projP2Entities db = new projP2Entities();

        // GET: aluno_curso
        public ActionResult Index()
        {
            var aluno_curso = db.aluno_curso.Include(a => a.aluno).Include(a => a.curso);
            return View(aluno_curso.ToList());
        }

        // GET: aluno_curso/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno_curso aluno_curso = db.aluno_curso.Find(id);
            if (aluno_curso == null)
            {
                return HttpNotFound();
            }
            return View(aluno_curso);
        }

        // GET: aluno_curso/Create
        public ActionResult Create()
        {
            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome");
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome");
            return View();
        }

        // POST: aluno_curso/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ra_aluno,id_curso,id")] aluno_curso aluno_curso)
        {
            if (ModelState.IsValid)
            {
                db.aluno_curso.Add(aluno_curso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome", aluno_curso.ra_aluno);
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome", aluno_curso.id_curso);
            return View(aluno_curso);
        }

        // GET: aluno_curso/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno_curso aluno_curso = db.aluno_curso.Find(id);
            if (aluno_curso == null)
            {
                return HttpNotFound();
            }
            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome", aluno_curso.ra_aluno);
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome", aluno_curso.id_curso);
            return View(aluno_curso);
        }

        // POST: aluno_curso/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ra_aluno,id_curso,id")] aluno_curso aluno_curso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno_curso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome", aluno_curso.ra_aluno);
            ViewBag.id_curso = new SelectList(db.curso, "id", "nome", aluno_curso.id_curso);
            return View(aluno_curso);
        }

        // GET: aluno_curso/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno_curso aluno_curso = db.aluno_curso.Find(id);
            if (aluno_curso == null)
            {
                return HttpNotFound();
            }
            return View(aluno_curso);
        }

        // POST: aluno_curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aluno_curso aluno_curso = db.aluno_curso.Find(id);
            db.aluno_curso.Remove(aluno_curso);
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

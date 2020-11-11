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
    public class aluno_disciplinaController : Controller
    {
        private projP2Entities db = new projP2Entities();

        // GET: aluno_disciplina
        public ActionResult Index()
        {
            var aluno_disciplina = db.aluno_disciplina.Include(a => a.aluno).Include(a => a.disciplina);
            return View(aluno_disciplina.ToList());
        }

        // GET: aluno_disciplina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno_disciplina aluno_disciplina = db.aluno_disciplina.Find(id);
            if (aluno_disciplina == null)
            {
                return HttpNotFound();
            }
            return View(aluno_disciplina);
        }

        // GET: aluno_disciplina/Create
        public ActionResult Create()
        {
            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome");
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome");
            return View();
        }

        // POST: aluno_disciplina/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ra_aluno,id_disciplina,ano,nota_p1,nota_p2,nota_p3,id")] aluno_disciplina aluno_disciplina)
        {
            if (ModelState.IsValid)
            {
                db.aluno_disciplina.Add(aluno_disciplina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome", aluno_disciplina.ra_aluno);
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome", aluno_disciplina.id_disciplina);
            return View(aluno_disciplina);
        }

        // GET: aluno_disciplina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno_disciplina aluno_disciplina = db.aluno_disciplina.Find(id);
            if (aluno_disciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome", aluno_disciplina.ra_aluno);
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome", aluno_disciplina.id_disciplina);
            return View(aluno_disciplina);
        }

        // POST: aluno_disciplina/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ra_aluno,id_disciplina,ano,nota_p1,nota_p2,nota_p3,id")] aluno_disciplina aluno_disciplina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno_disciplina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ra_aluno = new SelectList(db.aluno, "ra", "nome", aluno_disciplina.ra_aluno);
            ViewBag.id_disciplina = new SelectList(db.disciplina, "id", "nome", aluno_disciplina.id_disciplina);
            return View(aluno_disciplina);
        }

        // GET: aluno_disciplina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aluno_disciplina aluno_disciplina = db.aluno_disciplina.Find(id);
            if (aluno_disciplina == null)
            {
                return HttpNotFound();
            }
            return View(aluno_disciplina);
        }

        // POST: aluno_disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            aluno_disciplina aluno_disciplina = db.aluno_disciplina.Find(id);
            db.aluno_disciplina.Remove(aluno_disciplina);
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

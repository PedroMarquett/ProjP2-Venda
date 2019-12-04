using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prova2;

namespace Prova2.Controllers
{
    public class PrecoVendasController : Controller
    {
        private dbProj3Entities db = new dbProj3Entities();

        // GET: PrecoVendas
        public ActionResult Index()
        {
            var precoVenda = db.PrecoVenda.Include(p => p.Material1);
            return View(precoVenda.ToList());
        }

        // GET: PrecoVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoVenda precoVenda = db.PrecoVenda.Find(id);
            if (precoVenda == null)
            {
                return HttpNotFound();
            }
            return View(precoVenda);
        }

        // GET: PrecoVendas/Create
        public ActionResult Create()
        {
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao");
            return View();
        }

        // POST: PrecoVendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPrecoVenda,Material,preco")] PrecoVenda precoVenda)
        {
            if (ModelState.IsValid)
            {
                db.PrecoVenda.Add(precoVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", precoVenda.Material);
            return View(precoVenda);
        }

        // GET: PrecoVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoVenda precoVenda = db.PrecoVenda.Find(id);
            if (precoVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", precoVenda.Material);
            return View(precoVenda);
        }

        // POST: PrecoVendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPrecoVenda,Material,preco")] PrecoVenda precoVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precoVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", precoVenda.Material);
            return View(precoVenda);
        }

        // GET: PrecoVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoVenda precoVenda = db.PrecoVenda.Find(id);
            if (precoVenda == null)
            {
                return HttpNotFound();
            }
            return View(precoVenda);
        }

        // POST: PrecoVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecoVenda precoVenda = db.PrecoVenda.Find(id);
            db.PrecoVenda.Remove(precoVenda);
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

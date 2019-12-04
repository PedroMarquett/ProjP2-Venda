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
    public class PrecoComprasController : Controller
    {
        private dbProj3Entities db = new dbProj3Entities();

        // GET: PrecoCompras
        public ActionResult Index()
        {
            var precoCompra = db.PrecoCompra.Include(p => p.Material);
            return View(precoCompra.ToList());
        }

        // GET: PrecoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoCompra precoCompra = db.PrecoCompra.Find(id);
            if (precoCompra == null)
            {
                return HttpNotFound();
            }
            return View(precoCompra);
        }

        // GET: PrecoCompras/Create
        public ActionResult Create()
        {
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao");
            return View();
        }

        // POST: PrecoCompras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPrecoCompra,idMaterial,preco")] PrecoCompra precoCompra)
        {
            if (ModelState.IsValid)
            {
                db.PrecoCompra.Add(precoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", precoCompra.idMaterial);
            return View(precoCompra);
        }

        // GET: PrecoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoCompra precoCompra = db.PrecoCompra.Find(id);
            if (precoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", precoCompra.idMaterial);
            return View(precoCompra);
        }

        // POST: PrecoCompras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPrecoCompra,idMaterial,preco")] PrecoCompra precoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(precoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "descricao", precoCompra.idMaterial);
            return View(precoCompra);
        }

        // GET: PrecoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrecoCompra precoCompra = db.PrecoCompra.Find(id);
            if (precoCompra == null)
            {
                return HttpNotFound();
            }
            return View(precoCompra);
        }

        // POST: PrecoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrecoCompra precoCompra = db.PrecoCompra.Find(id);
            db.PrecoCompra.Remove(precoCompra);
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

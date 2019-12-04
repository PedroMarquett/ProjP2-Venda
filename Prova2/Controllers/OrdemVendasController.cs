﻿using System;
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
    public class OrdemVendasController : Controller
    {
        private dbProj3Entities db = new dbProj3Entities();

        // GET: OrdemVendas
        public ActionResult Index()
        {
            var ordemVenda = db.OrdemVenda.Include(o => o.Cliente1).Include(o => o.Material1).Include(o => o.PrecoVenda).ToList();
            return View(ordemVenda);
        }

        // GET: OrdemVendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemVenda ordemVenda = db.OrdemVenda.Find(id);
            if (ordemVenda == null)
            {
                return HttpNotFound();
            }
            return View(ordemVenda);
        }

        // GET: OrdemVendas/Create
        public ActionResult Create()
        {

            ViewBag.Cliente = new SelectList(db.Cliente, "idCliente", "Nome");
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao");
            ViewBag.Valor = new SelectList(db.PrecoVenda, "idPrecoVenda", "preco");
            return View();
        }

        // POST: OrdemVendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOrdemVenda,Material,Cliente,Valor,quantidade,data")] OrdemVenda ordemVenda)
        {
            if (ModelState.IsValid)
            {
                db.OrdemVenda.Add(ordemVenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente = new SelectList(db.Cliente, "idCliente", "Nome", ordemVenda.Cliente);
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", ordemVenda.Material);
            ViewBag.Valor = new SelectList(db.PrecoVenda, "idPrecoVenda", "preco", ordemVenda.Valor);
            return View(ordemVenda);
        }

        // GET: OrdemVendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemVenda ordemVenda = db.OrdemVenda.Find(id);
            if (ordemVenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente = new SelectList(db.Cliente, "idCliente", "Nome", ordemVenda.Cliente);
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", ordemVenda.Material);
            ViewBag.Valor = new SelectList(db.PrecoVenda, "idPrecoVenda", "preco", ordemVenda.Valor);
            return View(ordemVenda);
        }

        // POST: OrdemVendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOrdemVenda,Material,Cliente,Valor,quantidade,data")] OrdemVenda ordemVenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemVenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente = new SelectList(db.Cliente, "idCliente", "Nome", ordemVenda.Cliente);
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", ordemVenda.Material);
            ViewBag.Valor = new SelectList(db.PrecoVenda, "idPrecoVenda", "preco", ordemVenda.Valor);
            return View(ordemVenda);
        }

        // GET: OrdemVendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdemVenda ordemVenda = db.OrdemVenda.Find(id);
            if (ordemVenda == null)
            {
                return HttpNotFound();
            }
            return View(ordemVenda);
        }

        // POST: OrdemVendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemVenda ordemVenda = db.OrdemVenda.Find(id);
            db.OrdemVenda.Remove(ordemVenda);
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

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
    public class PedidoComprasController : Controller
    {
        private dbProj3Entities db = new dbProj3Entities();

        // GET: PedidoCompras
        public ActionResult Index()
        {
            var pedidoCompra = db.PedidoCompra.Include(p => p.Fornecedor1).Include(p => p.Material1).Include(p => p.PrecoCompra);
            return View(pedidoCompra.ToList());
        }

        // GET: PedidoCompras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            if (pedidoCompra == null)
            {
                return HttpNotFound();
            }
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Create
        public ActionResult Create()
        {
            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "idFornecedor", "Nome");
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao");
            ViewBag.Valor = new SelectList(db.PrecoCompra, "IdPrecoCompra", "preco");
            return View();
        }

        // POST: PedidoCompras/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPedCompra,Material,Fornecedor,Quantidade,Valor")] PedidoCompra pedidoCompra)
        {
            if (ModelState.IsValid)
            {
                db.PedidoCompra.Add(pedidoCompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "idFornecedor", "Nome", pedidoCompra.Fornecedor);
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", pedidoCompra.Material);
            ViewBag.Valor = new SelectList(db.PrecoCompra, "IdPrecoCompra", "preco", pedidoCompra.Valor);
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            if (pedidoCompra == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "idFornecedor", "Nome", pedidoCompra.Fornecedor);
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", pedidoCompra.Material);
            ViewBag.Valor = new SelectList(db.PrecoCompra, "IdPrecoCompra", "preco", pedidoCompra.Valor);
            return View(pedidoCompra);
        }

        // POST: PedidoCompras/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPedCompra,Material,Fornecedor,Quantidade,Valor")] PedidoCompra pedidoCompra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoCompra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Fornecedor = new SelectList(db.Fornecedor, "idFornecedor", "Nome", pedidoCompra.Fornecedor);
            ViewBag.Material = new SelectList(db.Material, "idMaterial", "descricao", pedidoCompra.Material);
            ViewBag.Valor = new SelectList(db.PrecoCompra, "preco", "preco", pedidoCompra.Material);
            return View(pedidoCompra);
        }

        // GET: PedidoCompras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            if (pedidoCompra == null)
            {
                return HttpNotFound();
            }
            return View(pedidoCompra);
        }

        // POST: PedidoCompras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoCompra pedidoCompra = db.PedidoCompra.Find(id);
            db.PedidoCompra.Remove(pedidoCompra);
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

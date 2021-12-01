using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Actividad3Prueba.Models;

namespace Actividad3Prueba.Controllers
{
    public class Orden_CompraPController : Controller
    {
        private contextAstillita db = new contextAstillita();

        // GET: Orden_CompraP
        public ActionResult Index()
        {
            var orden_Compra = db.Orden_Compra.Include(o => o.Clientes).Include(o => o.Pago).Include(o => o.Paqueteria);
            return View(orden_Compra.ToList());
        }

        public ActionResult IndexP()
        {
            var orden_Compra = db.Orden_Compra.Include(o => o.Clientes).Include(o => o.Pago).Include(o => o.Paqueteria);
            return View(orden_Compra.ToList());
        }

        public ActionResult IndexE()
        {
            var orden_Compra = db.Orden_Compra.Include(o => o.Clientes).Include(o => o.Pago).Include(o => o.Paqueteria);
            return View(orden_Compra.ToList());
        }

        // GET: Orden_CompraP/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_Compra orden_Compra = db.Orden_Compra.Find(id);
            if (orden_Compra == null)
            {
                return HttpNotFound();
            }
            return View(orden_Compra);
        }

        // GET: Orden_CompraP/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre");
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago");
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre");
            return View();
        }

        // POST: Orden_CompraP/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_orden,id_cliente,fecha_envio,fecha_entrega,id_paqueteria,nombreperona_envio,callenum_envio,ciudad_envio,codigop_envio,id_pago,status_envio,codigo_rastreo")] Orden_Compra orden_Compra)
        {
            if (ModelState.IsValid)
            {
                db.Orden_Compra.Add(orden_Compra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }

        // GET: Orden_CompraP/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_Compra orden_Compra = db.Orden_Compra.Find(id);
            if (orden_Compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }

        public ActionResult EditP(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_Compra orden_Compra = db.Orden_Compra.Find(id);
            if (orden_Compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditP([Bind(Include = "id_orden,id_cliente,fecha_envio,fecha_entrega,id_paqueteria,nombreperona_envio,callenum_envio,ciudad_envio,codigop_envio,id_pago,status_envio,codigo_rastreo")] Orden_Compra orden_Compra)
        {
            if (ModelState.IsValid)
            {
                int id_orden = orden_Compra.id_orden;
                var variable = db.Orden_Compra.Find(id_orden);
                //db.Entry(orden_Compra).State = EntityState.Modified;
                variable.fecha_envio = orden_Compra.fecha_envio;
                variable.fecha_entrega = orden_Compra.fecha_entrega;
                variable.id_paqueteria = orden_Compra.id_paqueteria;
                variable.status_envio = orden_Compra.status_envio;
                variable.codigo_rastreo = orden_Compra.codigo_rastreo;
                
                

                db.SaveChanges();
                return RedirectToAction("IndexP");
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }


        public ActionResult EditE(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_Compra orden_Compra = db.Orden_Compra.Find(id);
            if (orden_Compra == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }

        // POST: Orden_CompraP/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_orden,id_cliente,fecha_envio,fecha_entrega,id_paqueteria,nombreperona_envio,callenum_envio,ciudad_envio,codigop_envio,id_pago,status_envio,codigo_rastreo")] Orden_Compra orden_Compra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orden_Compra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditE([Bind(Include = "id_orden,id_cliente,fecha_envio,fecha_entrega,id_paqueteria,nombreperona_envio,callenum_envio,ciudad_envio,codigop_envio,id_pago,status_envio,codigo_rastreo")] Orden_Compra orden_Compra)
        {
            if (ModelState.IsValid)
            {
                int id_orden = orden_Compra.id_orden;
                var variable = db.Orden_Compra.Find(id_orden);
                //db.Entry(orden_Compra).State = EntityState.Modified;
                
                variable.fecha_entrega = orden_Compra.fecha_entrega;
                variable.status_envio = orden_Compra.status_envio;

                db.SaveChanges();
                return RedirectToAction("IndexE");
            }
            ViewBag.id_cliente = new SelectList(db.Clientes, "id_cliente", "nombre", orden_Compra.id_cliente);
            ViewBag.id_pago = new SelectList(db.Pago, "id_pago", "metodo_pago", orden_Compra.id_pago);
            ViewBag.id_paqueteria = new SelectList(db.Paqueteria, "id_paqueteria", "nombre", orden_Compra.id_paqueteria);
            return View(orden_Compra);
        }

        // GET: Orden_CompraP/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Orden_Compra orden_Compra = db.Orden_Compra.Find(id);
            if (orden_Compra == null)
            {
                return HttpNotFound();
            }
            return View(orden_Compra);
        }

        // POST: Orden_CompraP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orden_Compra orden_Compra = db.Orden_Compra.Find(id);
            db.Orden_Compra.Remove(orden_Compra);
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

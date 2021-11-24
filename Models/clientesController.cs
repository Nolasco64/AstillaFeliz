using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarpinteriaProyecto2.Models
{
    public class clientesController : Controller
    {
        private contextCarpinteriaProyecto db = new contextCarpinteriaProyecto();

        // GET: clientes
        public ActionResult Index()
        {
            return View(db.cliente.ToList());
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cliente,nombre,apellidos,edad,genero,direccion,correo,numTarjeta,tajetaexmes,tarjetexyear")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.tajetaexmes == 12 || cliente.tajetaexmes == 11)
                {

                    db.cliente.Add(cliente);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Invalida");
                }
            }

            return View(cliente);
        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cliente,nombre,apellidos,edad,genero,direccion,correo,numTarjeta,tajetaexmes,tarjetexyear")] cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if(cliente.tajetaexmes ==12 || cliente.tajetaexmes == 11)
                {
                    db.Entry(cliente).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Invalida");
                }

            }
            return View(cliente);
        }
        public ActionResult Invalida()
        {
            return View();
        }

        public ActionResult BorrarUser()
        {
            string idUser = User.Identity.GetUserId();
            return RedirectToAction("Delete", "Account", routeValues: new { id = idUser });

        }


        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cliente cliente = db.cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            cliente cliente = db.cliente.Find(id);
            db.cliente.Remove(cliente);
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

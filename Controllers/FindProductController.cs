using CarpinteriaProyecto2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarpinteriaProyecto2.Controllers
{
    public class FindProductController : Controller
    {
        private contextCarpinteriaProyecto db = new contextCarpinteriaProyecto();
        // GET: FindProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BuscaProd(string nomBuscar)
        {
            ViewBag.SearchKey = nomBuscar;
            using (db)
            {
                var query = from st in db.Productos where st.nombre.Contains(nomBuscar) select st;
                var listProd = query.ToList();

                ViewBag.Listado = listProd;
            }

            return View();
        }


        public ActionResult prodCategoria(int id)
        {
            List<Productos> mercancia = null;
            var query = from p in db.Productos where p.id_categoria == id select p;

            if (id == 1)
            {
                //List<Productos> lacteos = query.ToList();
                // mercancia = lacteos;
                mercancia = query.ToList();
                ViewBag.Catego = "Herramientas de Medicion";
            }
            if (id == 2)
            {
                List<Productos> carnes = query.ToList();
                mercancia = carnes;
                ViewBag.Catego = "Herramienta de Cortes";
            }

            if (id == 3)
            {
                List<Productos> panes = query.ToList();
                mercancia = panes;
                ViewBag.Catego = "Herramientas Electricas";

            }
            if (id == 4)
            {
                List<Productos> frut_veg = query.ToList();
                mercancia = frut_veg;
                ViewBag.Catego = "Frutas y Vegetales";
            }

            ViewBag.productos = mercancia;
            return View();
        }
    }
    
}
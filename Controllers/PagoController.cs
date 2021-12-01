using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AstillitaFeliz.Models;

namespace AstillitaFeliz.Controllers
{
    
    public class PagoController : Controller
    {
        private ContextAstillitaFeliz db = new ContextAstillitaFeliz();
        private string NumConfirPago;
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CrearOrden()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session["CrearOrden"] = "pend";
                return RedirectToAction("Login", "Account");
            }
            string correo = User.Identity.Name;
            string fechacreacion = DateTime.Today.ToShortDateString();
            string fechaProbEntrega = DateTime.Today.AddDays(3).ToShortDateString();
            var cliente = (from c in db.Clientes
                           where c.correo == correo
                           select c).ToList().FirstOrDefault();
            Session["dirCliente"] = cliente.direccion;
            Session["fechaOrden"] = fechacreacion;
            Session["fPEntreg"] = fechaProbEntrega;

            if (cliente.num_tarjeta.StartsWith("4"))
                Session["rTarj"] = "1";
            if (cliente.num_tarjeta.StartsWith("5"))
                Session["rTarj"] = "2";
            if (cliente.num_tarjeta.StartsWith("3"))
                Session["rTarj"] = "3";
            Session["nTarj"] = cliente.num_tarjeta;
            return View();

        }
        public ActionResult Pagar(string tipoPago)
        {
            string correo = User.Identity.Name;
            DateTime fechacreacion = DateTime.Today;
            DateTime fechaProbEntrega = DateTime.Today.AddDays(3);
            var cliente = (from c in db.Clientes
                           where c.correo == correo
                           select c).ToList().FirstOrDefault();
            int idClient = cliente.id_cliente;

            if (tipoPago.Equals("T"))
            {
                if (!validaPago(cliente))
                {
                    return RedirectToAction("pagoNoAceptado");
                }
                else
                {
                    var dirEnt = cliente.direccion;

                    return RedirectToAction("pagoAceptado", routeValues: new { idC = idClient });
                }
            }
            if (tipoPago.Equals("P"))
            {
                var dirEnt = cliente.direccion;
                validaPago(cliente);
                return RedirectToAction("pagoPaypal",routeValues:new { idC=idClient});
            }
            return View();

        }
        public ActionResult pagoAceptado(int idC)
        {
            Orden_Compra orden_cliente = new Orden_Compra();
            int id = 0;
            if (!(db.Orden_Compra.Max(o => (int?)o.id_orden)==null))
            {
                id = db.Orden_Compra.Max(o=>o.id_orden);
            }
            else
            {
                id = 0;
            }

            id++;
            orden_cliente.id_orden = id;
            orden_cliente.fecha_envio = DateTime.Today;
            orden_cliente.codigop_envio = Session["nConfirma"].ToString();
            var carro = Session["cart"] as List<Item>;
            var total = carro.Sum(item => item.product.precio * item.Cantidad);
            orden_cliente.total =(decimal) total;
            orden_cliente.id_cliente = idC;
            db.Orden_Compra.Add(orden_cliente);
            db.SaveChanges();

            Detalles_Compras ordenProd;
            List<Detalles_Compras> listaPordOrd = new List<Detalles_Compras>();
            foreach (Item linea in carro)
            {
                ordenProd = new Detalles_Compras();
                ordenProd.id_orden = orden_cliente.id_orden;
                ordenProd.id_producto = linea.product.id_producto;
                ordenProd.cantidad = linea.Cantidad;
                db.Detalles_Compras.Add(ordenProd);
            }
            db.SaveChanges();

            Session["cart"] = null;
            Session["nConfirma"] = null;
            Session["itemTotal"] = 0;
            return View();
        }

        public ActionResult pagoPaypal(int idC)
        {
            Session["idClient"] = idC;
            return View();
        }
        public ActionResult pagandoPaypal(int idC)
        {
            Session["idClient"] = idC;
            return View();
        }
        public ActionResult pagoNoAceptado()
        {
            return View();
        }
        private bool validaPago(Clientes cliente)
        {
            bool retorna = true;
            int randomvalue;
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                byte[] val = new byte[6];
                crypto.GetBytes(val);
                randomvalue = BitConverter.ToInt32(val,1);
            }
            NumConfirPago = Math.Abs(randomvalue * 1000).ToString();
            Session["nConfirma"] = NumConfirPago;
            return retorna;
        }
    }
}
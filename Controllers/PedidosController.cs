using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AstillitaFeliz.Models;


namespace AstillitaFeliz.Controllers
{
    [Authorize]
    public class PedidosController : Controller
    {
        ContextAstillitaFeliz db = new ContextAstillitaFeliz();
        // GET: Pedidos
        public ActionResult Index()
        {
            string correo = User.Identity.Name;
            Clientes cl = (from c in db.Clientes
                           where c.correo == correo
                           select c).ToList().FirstOrDefault();
            int id = cl.id_cliente;

            var query = from o in db.Orden_Compra
                        where o.id_cliente == id
                        orderby o.fecha_envio ascending
                        select o;

            List<Orden_Compra> ordenes = query.ToList();

            List<PedidoCliente> pedidos = new List<PedidoCliente>();
            PedidoCliente pedido;
            List<Detalles_Compras> orPed;
            List<ItemPedido> itemPed = new List<ItemPedido>();

            ItemPedido iPed;

            foreach (Orden_Compra o in ordenes){
                pedido = new PedidoCliente();
                pedido.Orden=o;
                pedido.fecha = o.fecha_envio.ToString();
                if (o.fecha_envio.HasValue)
                {
                    pedido.envio = o.fecha_envio.GetValueOrDefault().ToShortDateString();
                }
                else
                {
                    pedido.envio = "Proximamente";
                }
                if (o.fecha_entrega.HasValue)
                {
                    pedido.status = o.fecha_entrega.GetValueOrDefault().ToString();
                }
                else
                {
                    pedido.status = "Sin entregar";
                }
                pedido.Total = o.total.ToString();
                pedidos.Add(pedido);
                orPed = (from oP in db.Detalles_Compras
                         where oP.id_orden == o.id_orden
                         select oP).ToList();
                pedido.ordenProductos = orPed;
                foreach (Detalles_Compras op in orPed)
                {
                    iPed = new ItemPedido();
                    iPed.idOrd = o.id_orden;
                    iPed.Product = db.Producto.First(p => p.id_producto == op.id_producto);
                    iPed.Cantidad =(int) op.cantidad;
                    itemPed.Add(iPed);
                }
            }
            Session["misPedidos"] = pedidos;
            Session["Pedido"] = itemPed;
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstillitaFeliz.Models
{
    public class PedidoCliente
    {
        private ContextAstillitaFeliz db = new ContextAstillitaFeliz();
        private List<Detalles_Compras> detalle_orden;

        public PedidoCliente()
        {
            detalle_orden = db.Detalles_Compras.ToList();
        }
        public Orden_Compra Orden
        {
            get;
            set;
        }
        public string fecha
        {
            get;
            set;
        }
        public string envio
        {
            get;
            set;
        }
        public string status
        {
            get;
            set;
        }
        public string Total
        {
            get;
            set;
        }
        public List<Detalles_Compras> ordenProductos
        {
            get;
            set;
        }
    }
}
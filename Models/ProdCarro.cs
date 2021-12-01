using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstillitaFeliz.Models
{
    public class ProdCarro
    {
        private ContextAstillitaFeliz db = new ContextAstillitaFeliz();
        private List<Producto> products;
        public ProdCarro()
        {
            products = db.Producto.ToList();
        }

        public List<Producto> findAll()
        {
            return this.products;
        }

        public Producto find(int id)
        {
            Producto pp = this.products.Single(p => p.id_producto.Equals(id));
            return pp;
        }
    }
}
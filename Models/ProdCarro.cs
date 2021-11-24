using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpinteriaProyecto2.Models
{
    public class ProdCarro
    {
        private contextCarpinteriaProyecto db = new contextCarpinteriaProyecto();
        private List<Productos> products;
        public ProdCarro()
        {
            products = db.Productos.ToList();
        }

        public List<Productos> findAll()
        {
            return this.products;
        }

        public Productos find(int id)
        {
            Productos pp = this.products.Single(p => p.Id_producto.Equals(id));
            return pp;
        }
    }
}
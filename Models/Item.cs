using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AstillitaFeliz.Models
{
    public class Item
    {
        public Producto product
        {
            get;
            set;
        }

        public int Cantidad
        {
            get;
            set;
        }
    }
}
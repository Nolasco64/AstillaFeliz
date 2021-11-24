using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarpinteriaProyecto2.Models
{
    public class Item
    {
        public Productos product
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
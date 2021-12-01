using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AstillitaFeliz.Models;

namespace AstillitaFeliz.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private ContextAstillitaFeliz db=new ContextAstillitaFeliz();
        // GET: Usuario
    
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                string correo = email;
                var query1 = from st in db.Clientes
                             where st.correo == correo
                             select st;
                var lista1 = query1.ToList();
                if (lista1.Count > 0)
                {
                    var cliente = query1.FirstOrDefault<Clientes>();
                    string[] nombres = cliente.nombre.ToString().Split(' ');
                    Session["name"] = nombres[0];
                    Session["usr"] = cliente.nombre;
                    Session["id_C"] = cliente.id_cliente;
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
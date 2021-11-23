using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AstillitaFeliz.Models;

namespace AstillitaFeliz.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private contextAstillita db = new contextAstillita();

        // GET: Usuario
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                string correo = email;
                string rol = "";


                using (db)
                {
                    var query = from st in db.Empleados
                                where st.correo == correo
                                select st;
                    var lista = query.ToList();
                    if (lista.Count > 0)
                    {
                        var empleado = query.FirstOrDefault<Empleados>();
                        string[] nombres = empleado.nombre.ToString().Split(' ');
                        Session["name"] = nombres[0];
                        Session["usr"] = empleado.nombre;
                        rol = empleado.rol.ToString().TrimEnd();
                    }
                    else
                    {
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
                            rol = "cliente";
                        }
                    }

                }

                if (rol == "comprador")
                {
                    return RedirectToAction("Index", "Compras");
                }

                if (rol == "enviador")
                {
                    return RedirectToAction("Index", "Envios");
                }

                if (rol == "cliente")
                {
                    return RedirectToAction("Index", "Home");
                }

                if (rol == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

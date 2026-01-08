using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class NumeroController : Controller
    {
        // GET: Numero
        [HttpGet]
        public ActionResult SuperDigito()
        {
            ML.Result result = BL.Numero.GetAll();
            return View(result);
        }

        [HttpPost]
        public ActionResult SuperDigito(string numero)
        {

            int resultado = BL.Numero.CalcularSuperDigito(numero);

            BL.Numero.Insertar(numero, resultado);

            ML.Result result = BL.Numero.GetAll();

            ViewBag.SuperDigito = resultado;

            return View(result);
        }

        public ActionResult Delete()
        { 
            BL.Numero.Delete();
            return RedirectToAction("SuperDigito");
        }
    }
}
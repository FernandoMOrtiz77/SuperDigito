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
        //Con Linq
        public ActionResult CRUDLinq()
        {
            ML.Result result = BL.Numero.GetAllLINQ();
            return View(result);
        }

        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Form(string numero)
        {
            int resultado = BL.Numero.CalcularSuperDigito(numero);

            ML.Numerox numerox = new ML.Numerox
            {
                Numero = int.Parse(numero),
                Resultado = resultado
            };

            BL.Numero.AddLINQ(numerox);

            return RedirectToAction("CRUDLinq");
        }
        public ActionResult DeleteLINQ(int id)
        {
            BL.Numero.DeleteLINQ(id);
            return RedirectToAction("CRUDLinq");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ML.Result result = BL.Numero.GetByIdLINQ(id);
            if(result.Correct)
            {
                return View((ML.Numerox)result.Object);
            }
            return RedirectToAction("CRUDLinq");
        }

        [HttpPost]
        public ActionResult Edit(ML.Numerox numerox)
        {
            numerox.Resultado = BL.Numero.CalcularSuperDigito(numerox.Numero.ToString());
            BL.Numero.UpdateLINQ(numerox);
            return RedirectToAction("CRUDLinq");
        }
    }
}
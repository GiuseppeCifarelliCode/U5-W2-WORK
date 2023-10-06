using AlbergoCifa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbergoCifa.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View(DB.getAllClienti());
        }

        public ActionResult AddCliente(int id)
        {
            TempData["IdCamera"] = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddCliente(Cliente c)
        {
            if (ModelState.IsValid)
            {
                DB.AddCliente(c.Cognome, c.Nome, c.CF, c.Provincia, c.Citta, c.Email, c.Telefono, c.Cellulare);
                TempData["IdCliente"] = DB.getClienteByCF(c.CF).Id;
                return RedirectToAction("AddPrenotazione","Prenotazione");
            }
            else return View();
        }
    }
}
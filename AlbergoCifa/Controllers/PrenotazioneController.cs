using AlbergoCifa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlbergoCifa.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PrenotazioneController : Controller
    {

        // GET: Prenotazione
        public ActionResult Index()
        {
            ViewBag.ListaPrenotazioniConcluse = DB.getAllPrenotazioniConcluse();
            return View(DB.getAllPrenotazioniAttive());
        }
        public ActionResult AddPrenotazione()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPrenotazione(Prenotazione p)
        {
            if (ModelState.IsValid)
            {
                Camera c = DB.getCameraById((int)TempData["IdCamera"]);
                p.Tariffa = c.CalcolaTariffa(p.DataFine, p.DataInizio);
                p.IdCliente = (int)TempData["IdCliente"];
                p.IdCamera = c.Id;
                DB.AddPrenotazione(DateTime.Now, p.Anno, p.DataInizio, p.DataFine, p.Caparra, p.Tariffa, p.MezzaPensione, p.PrimaColazione, p.IdCliente, p.IdCamera);
                DB.changeCameraState(p.IdCamera);
                return RedirectToAction("Index","Camera");
            }
            else return View();

        }

    }
}